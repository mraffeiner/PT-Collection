using System;
using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class PlayerHealth : MonoBehaviour
    {
        public event Action<int> OnHealthChanged;

        [SerializeField] private GameObject gameOverScreen = null;
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private float hitRecoveryTime = 1f;

        private InputHandler inputHandler;
        private Animator animator;
        private CircleCollider2D hitbox;
        private int health = 0;
        private float hitRecoveryTimer = 0f;
        private int invincibleLayer;
        private int playerLayer;

        private void Awake()
        {
            inputHandler = FindObjectOfType<InputHandler>();
            animator = GetComponent<Animator>();
            hitbox = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            invincibleLayer = LayerMask.NameToLayer("Invincible");
            playerLayer = LayerMask.NameToLayer("Player");

            inputHandler.SwitchToGameplay();
            health = maxHealth;
            OnHealthChanged?.Invoke(health);
        }

        private void Update()
        {
            if (hitRecoveryTimer > 0f)
                hitRecoveryTimer -= Time.deltaTime;
            else if (gameObject.layer == invincibleLayer)
            {
                animator.SetBool("Invincible", false);
                gameObject.layer = playerLayer;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Enemy")
                TakeDamage(other.collider.GetComponent<Enemy>().Stats.AttackDamage);
        }

        private void TakeDamage(int value)
        {
            if (value == 0 || gameObject.layer == invincibleLayer)
                return;

            gameObject.layer = invincibleLayer;
            hitRecoveryTimer = hitRecoveryTime;
            animator.SetBool("Invincible", true);

            health = Mathf.Clamp(health - value, 0, maxHealth);
            OnHealthChanged?.Invoke(health);

            if (health <= 0)
                Lose();
        }

        public void Lose()
        {
            gameOverScreen.SetActive(true);
            inputHandler.SwitchToUI();

            gameObject.SetActive(false);
        }
    }
}
