using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public Vector2 scale;
    public int maxHealth;
    public float moveSpeed;
    public float slowRecoverySpeed;
    public int damage;
    public int value;
}
