using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStats stats = null;

    public int Health { get; private set; }

    private void Start()
    {
        GetComponent<AIDestinationSetter>().target = GameObject.Find("Despawn").transform;
        GetComponent<AIPath>().maxSpeed = stats.moveSpeed;
    }

    private void OnEnable() => Health = stats.maxHealth;

    public void TakeDamage(int value)
    {
        Health = Mathf.Clamp(Health - value, 0, stats.maxHealth);

        if (Health <= 0)
            gameObject.SetActive(false);
    }
}
