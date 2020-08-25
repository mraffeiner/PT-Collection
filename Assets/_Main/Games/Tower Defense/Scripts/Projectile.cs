using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 targetOffset = new Vector3(1f, .01f, 0f);

    public SpriteRenderer SpriteRenderer { get; private set; }
    public Enemy Target { get; set; }
    public int Damage { get; set; }
    public float Speed { get; set; }

    private void Awake() => SpriteRenderer = GetComponent<SpriteRenderer>();

    private void LateUpdate()
    {
        var targetPosition = Target.transform.position + targetOffset;

        if (Vector2.Distance(transform.position, targetPosition) > .1f)
        {
            var directionToTarget = (targetPosition - transform.position).normalized;
            transform.position += directionToTarget * Speed;
        }
        else
        {
            Target.TakeDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}
