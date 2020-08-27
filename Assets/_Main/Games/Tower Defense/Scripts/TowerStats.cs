using UnityEngine;

[CreateAssetMenu]
public class TowerStats : ScriptableObject
{
    public int cost;
    public float attackRange;
    public int attackDamage;
    public float damageRadius;
    public float slowStrength;
    public float attacksPerSecond;
    public Color projectileColor;
    public float projectileSpeed;
}
