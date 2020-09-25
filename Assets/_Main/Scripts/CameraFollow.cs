using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private BoxCollider2D followBounds = null;
    [SerializeField] private float lookAheadMultiplier = 0f;
    [SerializeField] private float smoothTime = 0f;
    [SerializeField] private bool ignoreX = false;
    [SerializeField] private bool ignoreY = false;

    float cameraExtentX;
    float cameraExtentY;
    private Vector3 newPosition = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D targetRigidBody = null;

    private void Awake() => targetRigidBody = target.GetComponent<Rigidbody2D>();

    private void Start()
    {
        cameraExtentY = Camera.main.orthographicSize;
        cameraExtentX = cameraExtentY * Screen.width / Screen.height;
    }

    private void Update()
    {
        newPosition = transform.position;

        if (!ignoreX)
        {
            var x = target.position.x + (targetRigidBody != null ? targetRigidBody.velocity.x * lookAheadMultiplier : 0f);
            if (followBounds != null)
            {
                var min = followBounds.transform.position.x - followBounds.size.x / 2f + cameraExtentX;
                var max = followBounds.transform.position.x + followBounds.size.x / 2f - cameraExtentX;
                x = Mathf.Clamp(x, min, max);
            }

            newPosition.x = x;
        }
        if (!ignoreY)
        {
            var y = target.position.y + (targetRigidBody != null ? targetRigidBody.velocity.y * lookAheadMultiplier : 0f);
            if (followBounds != null)
            {
                var min = followBounds.transform.position.y - followBounds.size.y / 2f + cameraExtentY;
                var max = followBounds.transform.position.y + followBounds.size.y / 2f - cameraExtentY;
                y = Mathf.Clamp(y, min, max);
            }

            newPosition.y = y;
        }
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
