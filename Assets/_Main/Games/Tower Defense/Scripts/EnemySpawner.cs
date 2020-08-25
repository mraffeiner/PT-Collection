using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public event Action<Transform, EnemyStats> SpawnEnemy;

    [SerializeField] private EnemySpawnSettings settings = null;
    [SerializeField] private Transform spawn = null;

    private Queue<EnemyStats> enemies;

    private void Start()
    {
        enemies = new Queue<EnemyStats>();
        for (int i = 0; i < settings.enemyAmount; i++)
            enemies.Enqueue(settings.enemyType);

        Random.InitState(settings.seed);
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(1f);

        while (enemies.Count > 0)
        {
            var enemy = enemies.Dequeue();
            SpawnEnemy?.Invoke(spawn, enemy);

            yield return new WaitForSeconds(Random.Range(settings.timeBetweenSpawnsMin, settings.timeBetweenSpawnsMax));
        }
    }
}
