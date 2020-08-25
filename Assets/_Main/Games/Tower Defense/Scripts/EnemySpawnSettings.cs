using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemySpawnSettings : ScriptableObject
{
    public int enemyAmount;
    public EnemyStats enemyType;
    public float timeBetweenSpawns;
}
