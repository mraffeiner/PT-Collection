using UnityEngine;

namespace PTCollection.TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Tower Defense/Enemy Stats")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private Vector2 scale = Vector2.one;
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int damage = 1;
        [SerializeField] private int value = 1;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float slowRecoverySpeed = 1f;

        public Vector2 Scale => scale;
        public int MaxHealth => maxHealth;
        public float MoveSpeed => moveSpeed;
        public float SlowRecoverySpeed => slowRecoverySpeed;
        public int Damage => damage;
        public int Value => value;
    }
}
