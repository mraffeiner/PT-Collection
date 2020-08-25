using UnityEngine;

public class EnemyPool : ObjectPoolBase
{
    private EnemySpawner spawner;

    private void Awake() => spawner = FindObjectOfType<EnemySpawner>();

    private void OnEnable() => spawner.SpawnEnemy += OnEnemySpawnEvent;
    
    private void OnDisable() => spawner.SpawnEnemy -= OnEnemySpawnEvent;

    private void OnEnemySpawnEvent(Transform spawn, EnemyStats stats)
    {
        var enemyObject = GetInactiveFromPool();
        var enemyComponent = enemyObject.GetComponent<Enemy>();

        enemyObject.transform.position = spawn.position;
        enemyObject.transform.rotation = spawn.rotation;

        enemyObject.SetActive(true);
    }
}
