using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    [CreateAssetMenu(menuName = "Scriptable Object/Twin Stick Shooter/Enemy Stats")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private int attackDamage = 1;
        [SerializeField] private int moveSpeed = 5;

        public int MaxHealth => maxHealth;
        public int AttackDamage => attackDamage;
        public int MoveSpeed => moveSpeed;
    }
}
