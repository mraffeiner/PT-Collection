using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class ColliderFitter : MonoBehaviour
{
    [Tooltip("Offset the size of the collider by this value")]
    [SerializeField] private float padding = -.1f;

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var newSize = Vector2.one;

        newSize.x = spriteRenderer.size.x + padding;
        newSize.y = spriteRenderer.size.y + padding;

        boxCollider.size = newSize;
    }
}
