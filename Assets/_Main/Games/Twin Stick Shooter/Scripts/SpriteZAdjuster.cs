using UnityEngine;

public class SpriteZAdjuster : MonoBehaviour
{
    [SerializeField] private Transform spriteRoot = null;

    private void Update()
    {
        if (spriteRoot.localPosition.z != transform.position.y)
            spriteRoot.localPosition = new Vector3(spriteRoot.localPosition.x, spriteRoot.localPosition.y, transform.position.y);
    }
}
