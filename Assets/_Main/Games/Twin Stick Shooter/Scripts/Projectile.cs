using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class Projectile : MonoBehaviour
    {
        public PlayerStats Stats { get; set; }

        private Rigidbody2D body;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();

            gameObject.SetActive(false);
        }

        private void Update()
        {
            body.MovePosition(body.position + (Vector2)transform.right * Stats.ProjectileSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<Enemy>().TakeDamage(Stats.AttackDamage);
                gameObject.SetActive(false);
            }
            else if (other.tag == "Wall")
                gameObject.SetActive(false);
        }
    }
}
