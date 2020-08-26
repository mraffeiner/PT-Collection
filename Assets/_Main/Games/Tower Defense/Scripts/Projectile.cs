using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 targetOffset = new Vector3(1f, .01f, 0f);

    public SpriteRenderer SpriteRenderer { get; private set; }
    public Enemy Target { get; set; }
    public int Damage { get; set; }
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
        Enemy.Die += OnEnemyRemoved;
        core.EnemyEntered += OnEnemyRemoved;
    }
    private void OnDestroy()
    {
        Enemy.Die -= OnEnemyRemoved;
        core.EnemyEntered -= OnEnemyRemoved;
    }
    private void FixedUpdate()
    {
        if (Target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        targetPosition = Target.transform.position + targetOffset;
        if (Vector2.Distance(targetPosition, transform.position) > .3f)
            transform.position += (targetPosition - transform.position).normalized * Speed * Time.deltaTime;
        else
        {
            Target.TakeDamage(Damage);
            gameObject.SetActive(false);
        }
    }

    private void OnEnemyRemoved(Enemy enemy)
    {
        if (Target == enemy)
            Target = null;
    }
}
