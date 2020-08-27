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
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private List<EnemyWave> waves = null;
    [SerializeField] private bool endless = false;
    [SerializeField] private float endlessGrowthFactor = .5f;

    private EnemyWave currentWave;
    private int waveCounter;

    private void Start()
    {
        SpawnNextWave();
    }

    private void SpawnNextWave()
    {
        waveCounter++;

        waveText.text = waveCounter.ToString();

        if (waves.Count <= 0)
        {
            if (endless)
            {
                var nextWave = Instantiate(currentWave);
                nextWave.enemyAmount = Mathf.RoundToInt(nextWave.enemyAmount * (1 + endlessGrowthFactor));
                currentWave = nextWave;
                StartCoroutine(WaveSpawnLoop(currentWave));
            }
            else
                Debug.Log("Waves complete");

            return;
        }

        currentWave = waves.First();
        waves.Remove(currentWave);
        StartCoroutine(WaveSpawnLoop(currentWave));
    }

    private IEnumerator WaveSpawnLoop(EnemyWave wave)
    {
        Queue<EnemyStats> enemies = new Queue<EnemyStats>();
        for (int i = 0; i < wave.enemyAmount; i++)
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
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnNextWave();
        }
    }
}
