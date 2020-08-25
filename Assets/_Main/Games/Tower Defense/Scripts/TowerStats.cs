using UnityEngine;

[CreateAssetMenu]
public class TowerStats : ScriptableObject
{
    public int attackDamage;
    public float attackRange;
    public float attackCooldown;

    public Sprite projectileSprite;
    public float projectileSpeed;
}
