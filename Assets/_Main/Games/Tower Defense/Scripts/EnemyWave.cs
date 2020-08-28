using UnityEngine;

[CreateAssetMenu]
public class EnemyWave : ScriptableObject
{
    public int waveSize;
    public EnemyStats enemyType;
    public float spawnRate;
    public float spawnRateVariance;
    public int seed;
}
