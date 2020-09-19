using UnityEngine;

namespace PTCollection.TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        public Enemy Target { get; set; }
        public TowerStats Stats { get; set; }

        public SpriteRenderer SpriteRenderer { get; private set; }

        private Core core;
        Vector3 targetPosition = Vector3.zero;

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            core = GameObject.FindObjectOfType<Core>();
        }

        private void Start()
        {
            Enemy.Died += OnEnemyRemoved;
            core.EnemyEntered += OnEnemyRemoved;
        }

        private void OnDestroy()
        {
            Enemy.Died -= OnEnemyRemoved;
            core.EnemyEntered -= OnEnemyRemoved;
        }

        private void Update()
        {
            if (Target != null)
                targetPosition = Target.transform.position;

            Move();
        }

        private void Move()
        {
            var vectorToTarget = targetPosition - transform.position;
            var moveVector = (vectorToTarget.normalized * Stats.ProjectileSpeed) * Time.deltaTime;

            var distanceBeforeMoving = vectorToTarget.sqrMagnitude;
            var distanceAfterMoving = (targetPosition - (transform.position + moveVector)).sqrMagnitude;

            if (distanceBeforeMoving < .1f || distanceAfterMoving > distanceBeforeMoving)
            {
                DealDamage();
                gameObject.SetActive(false);
            }
            else
                transform.position += moveVector;
        }

        private void DealDamage()
        {
            if (Stats.DamageRadius > 0f)
            {
                var hits = Physics2D.OverlapCircleAll(targetPosition, Stats.DamageRadius);
                foreach (var hit in hits)
                {
                    var enemy = hit.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        if (Stats.SlowStrength > 0f)
                            enemy.AddSlow(1f - Stats.SlowStrength, Stats.SlowDuration);
                        enemy.TakeDamage(Stats.AttackDamage);
                    }
                }
            }
            else if (Target != null)
            {
                if (Stats.SlowStrength > 0f)
                    Target.AddSlow(1f - Stats.SlowStrength, Stats.SlowDuration);
                Target.TakeDamage(Stats.AttackDamage);
            }
        }

        private void OnEnemyRemoved(Enemy enemy)
        {
            if (Target == enemy)
                Target = null;
        }
    }
}
