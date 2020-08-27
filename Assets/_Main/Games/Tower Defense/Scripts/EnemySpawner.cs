using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public event Action<Transform, EnemyStats> SpawnEnemy;

    [SerializeField] private Transform spawn = null;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private List<EnemyWave> waves = null;

    private EnemyWave currentWave;

    private void Start()
    {
        SpawnNextWave();
    }

    private void SpawnNextWave()
    {
        if (waves.Count <= 0)
        {
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

            var spawnDelayMin = 1 / wave.spawnRate;
            var spawnDelayMax = spawnDelayMin + wave.spawnRateVariance;
            var spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
            yield return new WaitForSeconds(spawnDelay);
        }

        if (currentWave == wave)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnNextWave();
        }
    }
}
