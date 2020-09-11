using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class ColliderFitter : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider = null;
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    [Tooltip("Offset the size of the collider by this value")]
    [SerializeField] private float padding = -.1f;

    private void Awake() => ApplyFit();

    [ContextMenu("Apply Fit")]
    public void ApplyFit()
    {
        var newSize = Vector2.one;

        newSize.x = spriteRenderer.size.x + padding;
        newSize.y = spriteRenderer.size.y + padding;

        boxCollider.size = newSize;
    }
}
