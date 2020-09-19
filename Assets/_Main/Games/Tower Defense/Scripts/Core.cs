using System;
using TMPro;
using UnityEngine;

namespace PTCollection.TowerDefense
{
    public class Core : MonoBehaviour
    {
        public event Action<Enemy> EnemyEntered;

        [SerializeField] private GameObject gameOverScreen = null;
        [SerializeField] private TextMeshProUGUI healthText = null;
        [SerializeField] private int maxHealth = 100;

        private InputHandler towerDefenseController;
        private int health;

        private int Health
        {
            get => health; set
            {
                health = value;
                healthText.text = health.ToString();
            }
        }

        private void Awake() => towerDefenseController = FindObjectOfType<InputHandler>();

        private void Start()
        {
            Health = maxHealth;
            towerDefenseController.enabled = true;
            GameSpeed.Factor = 1F;
        }

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
                Lose();
                enabled = false;
            }
        }

        public void Lose()
        {
            GameSpeed.Factor = .2f;
            towerDefenseController.enabled = false;
            gameOverScreen.SetActive(true);
        }
    }
}
