using UnityEngine;

public class EnemyPool : ObjectPoolBase
{
    private WaveSpawner spawner;

    private void Awake() => spawner = FindObjectOfType<WaveSpawner>();

    private void OnEnable() => spawner.SpawnEnemy += OnEnemySpawned;

    private void OnDisable() => spawner.SpawnEnemy -= OnEnemySpawned;

    private void OnEnemySpawned(Transform spawn, EnemyStats stats)
    {
        var enemyObject = GetInactiveFromPool();
        var enemyComponent = enemyObject.GetComponent<Enemy>();

        enemyObject.transform.position = spawn.position;
        enemyObject.transform.rotation = spawn.rotation;
        enemyObject.transform.localScale = stats.Scale;

        enemyComponent.Stats = stats;

        enemyObject.SetActive(true);
    }
}
