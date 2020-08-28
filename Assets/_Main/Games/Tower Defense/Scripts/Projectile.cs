using UnityEngine;

public class Projectile : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    public Enemy Target { get; set; }
    public int Damage { get; set; }
    public float DamageRadius { get; set; }
    public float SlowStrength { get; set; }
    public float SlowDuration { get; set; }
    public float Speed { get; set; }

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
    private void FixedUpdate()
    {
        if (Target != null)
            targetPosition = Target.transform.position;

        if (Vector2.Distance(targetPosition, transform.position) > .3f)
            transform.position += (targetPosition - transform.position).normalized * Speed * Time.deltaTime;
        else
        {
            var hits = Physics2D.OverlapCircleAll(targetPosition, DamageRadius);
            foreach (var hit in hits)
            {
                var enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                    if (SlowStrength > 0f)
                        enemy.AddSlow(1f - SlowStrength, SlowDuration);
                }
            }
            gameObject.SetActive(false);
        }
    }

    private void OnEnemyRemoved(Enemy enemy)
    {
        if (Target == enemy)
            Target = null;
    }
}
