using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using System;

namespace PTCollection.TwinStickShooter
{
    public class Enemy : MonoBehaviour
    {
        public static event Action<Enemy> Died;

        [SerializeField] private CanvasGroup healthbarCanvasGroup = null;
        [SerializeField] private Image healthbarFillImage = null;
        [SerializeField] private EnemyStats stats = null;

        public EnemyStats Stats => stats;

        private AIPath aiPath;
        // private float slowTimer = 0f;

        private int health;
        private int Health
        {
            get => health; set
            {
                health = value;
                healthbarFillImage.fillAmount = (float)Health / (float)stats.MaxHealth;
            }
        }

        private void Awake()
        {
            GetComponent<AIDestinationSetter>().target = GameObject.FindWithTag("Player").transform;
            aiPath = GetComponent<AIPath>();
        }

        private void Start() => aiPath.maxSpeed = stats.MoveSpeed;

        private void OnEnable()
        {
            Health = stats.MaxHealth;

            healthbarCanvasGroup.alpha = 0f;
            // slowTimer = 0f;
        }

        private void Update()
        {
            // if (slowTimer > 0f)
            //     slowTimer -= Time.deltaTime;
            // else if (slowTimer <= 0f && aiPath.maxSpeed < stats.MoveSpeed)
            //     aiPath.maxSpeed = Mathf.Clamp(aiPath.maxSpeed + stats.SlowRecoverySpeed * Time.deltaTime, 0f, stats.MoveSpeed);
        }

        public void Reveal() => healthbarCanvasGroup.alpha = 1f;

        public void Hide() => healthbarCanvasGroup.alpha = 0f;

        public void TakeDamage(int value)
        {
            Health = Mathf.Clamp(Health - value, 0, stats.MaxHealth);

            if (Health <= 0)
            {
                Died?.Invoke(this);
                gameObject.SetActive(false);
            }
        }

        // public void AddSlow(float value, float duration)
        // {
        //     slowTimer = duration;
        //     aiPath.maxSpeed = stats.MoveSpeed * value;
        // }
    }
}
