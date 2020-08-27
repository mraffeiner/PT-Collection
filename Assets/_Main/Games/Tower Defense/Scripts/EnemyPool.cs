using UnityEngine;

public class EnemyPool : ObjectPoolBase
{
    private WaveSpawner spawner;

    private void Awake() => spawner = FindObjectOfType<WaveSpawner>();

    private void OnEnable() => spawner.SpawnEnemy += OnEnemySpawnEvent;

    private void OnDisable() => spawner.SpawnEnemy -= OnEnemySpawnEvent;

    private void OnEnemySpawnEvent(Transform spawn, EnemyStats stats)
    {
        var enemyObject = GetInactiveFromPool();
        var enemyComponent = enemyObject.GetComponent<Enemy>();

        enemyObject.transform.position = spawn.position;
        enemyObject.transform.rotation = spawn.rotation;
        enemyObject.transform.localScale = stats.scale;

        enemyComponent.MaxHealth = stats.maxHealth;
        enemyComponent.Damage = stats.damage; ;
        enemyComponent.Value = stats.value; ;
        enemyComponent.MoveSpeed = stats.moveSpeed; ;
        enemyComponent.SlowRecoverySpeed = stats.slowRecoverySpeed; ;

        enemyObject.SetActive(true);
    }
}
