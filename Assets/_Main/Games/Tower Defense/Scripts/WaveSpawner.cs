using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public event Action<Transform, EnemyStats> SpawnEnemy;

    [SerializeField] private TextMeshProUGUI waveText = null;
    [SerializeField] private Transform spawn = null;
    [SerializeField] private List<EnemyWave> waves = null;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private bool endless = false;
    [SerializeField] private float waveSizeGrowthFactor = .2f;
    [SerializeField] private int waveSizeCap = 1000;
    [SerializeField] private float spawnRateGrowthFactor = .1f;
    [SerializeField] private int spawnRateCap = 10;

    private Core core;
    private EnemyWave currentWave;
    private List<Enemy> activeEnemies;

    private int waveCounter;
    private int WaveCounter
    {
        get => waveCounter; set
        {
            waveCounter = value;
            waveText.text = waveCounter.ToString();
        }
    }

    private void Awake() => core = FindObjectOfType<Core>();

    private void Start()
    {
        WaveCounter = 1;
        activeEnemies = new List<Enemy>();
        Invoke("SpawnNextWave", 5f);
    }

    private void OnEnable()
    {
        Enemy.Spawned += OnEnemyAdded;
        Enemy.Died += OnEnemyRemoved;

        core.EnemyEntered += OnEnemyRemoved;
    }

    private void OnDisable()
    {
        Enemy.Spawned -= OnEnemyAdded;
        Enemy.Died -= OnEnemyRemoved;

        core.EnemyEntered -= OnEnemyRemoved;
    }

    public void SkipWave()
    {
        WaveCounter++;
        SpawnNextWave();
    }

    private void OnEnemyAdded(Enemy enemy) => activeEnemies.Add(enemy);

    private void OnEnemyRemoved(Enemy enemy) => activeEnemies.Remove(enemy);

    private void SpawnNextWave()
    {
        if (waves.Count <= 0)
        {
            if (endless)
            {
                var nextWave = Instantiate(currentWave);

                if (nextWave.waveSize < waveSizeCap)
                    nextWave.waveSize = Mathf.RoundToInt(nextWave.waveSize * (1 + waveSizeGrowthFactor));

                if (nextWave.spawnRate < spawnRateCap)
                    nextWave.spawnRate = nextWave.spawnRate * (1 + spawnRateGrowthFactor);

                StartCoroutine(EnemySpawnLoop(nextWave));

                currentWave = nextWave;
            }
            else
                Debug.Log("Stage Clear");

            return;
        }

        currentWave = waves.First();
        waves.Remove(currentWave);
        StartCoroutine(EnemySpawnLoop(currentWave));
    }

    private IEnumerator EnemySpawnLoop(EnemyWave wave)
    {
        Queue<EnemyStats> enemies = new Queue<EnemyStats>();
        for (int i = 0; i < wave.waveSize; i++)
            enemies.Enqueue(wave.enemyType);

        Random.InitState(wave.seed);

        while (enemies.Count > 0)
        {
            var enemy = enemies.Dequeue();
            SpawnEnemy?.Invoke(spawn, enemy);

            var spawnDelayBase = 1 / wave.spawnRate;
            var spawnDelayVariance = spawnDelayBase * wave.spawnRateVariance;

            yield return new WaitForSeconds(Random.Range(spawnDelayBase - spawnDelayVariance, spawnDelayBase + spawnDelayVariance));
        }

        if (currentWave == wave)
        {
            while (activeEnemies.Count > 0)
                yield return new WaitForSeconds(.1f);

            Debug.Log("Wave Clear");

            yield return new WaitForSeconds(timeBetweenWaves);

            WaveCounter++;
            SpawnNextWave();
        }
    }
}
