using System;
using TMPro;
using UnityEngine;

public class Core : MonoBehaviour
{
    public event Action<Enemy> EnemyEntered;

    [SerializeField] private TextMeshProUGUI healthText = null;
    [SerializeField] private int maxHealth = 100;

    private GameController gameController;

    private void Awake() => gameController = FindObjectOfType<GameController>();

    private int health;
    private int Health
    {
        get => health; set
        {
            health = value;
            healthText.text = health.ToString();
        }
    }

    private void Start() => Health = maxHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null)
            return;

        Health = Mathf.Clamp(Health - enemy.Stats.Damage, 0, maxHealth);
        EnemyEntered?.Invoke(enemy);
        enemy.gameObject.SetActive(false);

        if (Health <= 0)
        {
            gameController.Lose();
            enabled = false;
        }
    }
}
