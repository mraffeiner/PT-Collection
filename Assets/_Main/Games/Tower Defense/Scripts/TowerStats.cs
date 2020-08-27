using UnityEngine;

[CreateAssetMenu]
public class TowerStats : ScriptableObject
{
    public int cost;
    public int attackDamage;
    public float attackRange;
    public float attacksPerSecond;
    public Color projectileColor;
    public float projectileSpeed;
}
