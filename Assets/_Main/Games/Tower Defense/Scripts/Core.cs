using System;
using TMPro;
using UnityEngine;

public class Core : MonoBehaviour
{
    public event Action<Enemy> EnemyEntered;

    [SerializeField] private TextMeshProUGUI healthText = null;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;

    private void Start()
    {
        health = maxHealth;

        healthText.text = health.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null)
            return;

        health = Mathf.Clamp(health - enemy.Damage, 0, maxHealth);
        EnemyEntered?.Invoke(enemy);
        enemy.gameObject.SetActive(false);

        healthText.text = health.ToString();

        if (health <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }
}
