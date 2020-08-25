using System;
using UnityEngine;

public class Core : MonoBehaviour
{
    public event Action<Enemy> EnemyEntered;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;

    private void Start() => health = maxHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null)
            return;

        health = Mathf.Clamp(health - enemy.Damage, 0, maxHealth);
        EnemyEntered?.Invoke(enemy);
        enemy.gameObject.SetActive(false);

        if (health <= 0)
            Debug.Log("Game Over");
    }
}
