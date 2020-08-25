using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (enemies.Count > 0)
        {
            var enemy = enemies.Dequeue();
            SpawnEnemy?.Invoke(spawn, enemy);

            yield return new WaitForSeconds(settings.timeBetweenSpawns);
        }
    }
}
