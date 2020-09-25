using UnityEngine;

namespace PTCollection.TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Tower Defense/Enemy Wave")]
    public class EnemyWave : ScriptableObject
    {
        public int waveSize;
        public EnemyStats enemyType;
        public float spawnRate;
        public float spawnRateVariance;
        public int seed;
    }
}
