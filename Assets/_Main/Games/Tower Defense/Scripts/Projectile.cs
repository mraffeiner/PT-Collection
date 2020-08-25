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
    private bool targetValid = true;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        core = GameObject.FindObjectOfType<Core>();
    }

    private void Start() => core.EnemyEntered += OnEnemyEnteredCore;

    private void OnDestroy() => core.EnemyEntered -= OnEnemyEnteredCore;

    private void OnEnable() => targetValid = true;

    private void LateUpdate()
    {
        if (Target.Health <= 0)
            targetValid = false;

        if (targetValid)
        {
            targetPosition = Target.transform.position + targetOffset;
            SeekAliveTarget();
        }
        else
            SeekDeadTarget();
    }

    private void OnEnemyEnteredCore(Enemy enemy)
    {
        if (Target == enemy)
            targetValid = false;
    }

    private void SeekAliveTarget()
    {
        if (Vector2.Distance(targetPosition, transform.position) > .1f)
            transform.position += (targetPosition - transform.position).normalized * Speed;
        else
        {
            Target.TakeDamage(Damage);
            gameObject.SetActive(false);
        }
    }

    private void SeekDeadTarget()
    {
        if (Vector2.Distance(targetPosition, transform.position) > .1f)
            transform.position += (targetPosition - transform.position).normalized * Speed;
        else
            gameObject.SetActive(false);
    }
}
