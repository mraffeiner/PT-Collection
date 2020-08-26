using UnityEngine;

[CreateAssetMenu]
public class TowerStats : ScriptableObject
{
    public int attackDamage;
    public float attackRange;
    public float attacksPerSecond;
    public Sprite projectileSprite;
    public float projectileSpeed;
}
