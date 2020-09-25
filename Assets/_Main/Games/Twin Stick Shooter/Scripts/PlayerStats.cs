using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    [CreateAssetMenu(menuName = "Scriptable Object/Twin Stick Shooter/Player Stats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private int attackDamage = 1;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private float moveSpeed = 10f;

        public int AttackDamage => attackDamage;
        public float AttackCooldown => attackCooldown;
        public float ProjectileSpeed => projectileSpeed;
        public float MoveSpeed => moveSpeed;
    }
}
