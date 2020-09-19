using UnityEngine;

namespace PTCollection.TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Tower Stats")]
    public class TowerStats : ScriptableObject
    {
        [SerializeField] private int cost = 50;
        [SerializeField] private int attackDamage = 50;
        [SerializeField] private float attackRange = 5f;
        [SerializeField] private float damageRadius = 0f;
        [SerializeField] private float slowStrength = 0f;
        [SerializeField] private float slowDuration = 0f;
        [SerializeField] private float attacksPerSecond = 1f;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private Color projectileColor = Color.white;

        public int Cost => cost;
        public float AttackRange => attackRange;
        public int AttackDamage => attackDamage;
        public float DamageRadius => damageRadius;
        public float SlowStrength => slowStrength;
        public float SlowDuration => slowDuration;
        public float AttacksPerSecond => attacksPerSecond;
        public Color ProjectileColor => projectileColor;
        public float ProjectileSpeed => projectileSpeed;
    }
}
