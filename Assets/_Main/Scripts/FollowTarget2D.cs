using UnityEngine;

public class FollowTarget2D : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float lookAheadMultiplier = 0f;
    [SerializeField] private float smoothTime = 0f;
    [SerializeField] private bool ignoreX = false;
    [SerializeField] private bool ignoreY = false;

    private Vector3 newPosition = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D targetRigidBody = null;

    private void Awake() => targetRigidBody = target.GetComponent<Rigidbody2D>();

    private void Update()
    {
        newPosition = transform.position;
        if (!ignoreX)
            newPosition.x = target.position.x + (targetRigidBody != null ? targetRigidBody.velocity.x * lookAheadMultiplier : 0f);
        if (!ignoreY)
            newPosition.y = target.position.y + (targetRigidBody != null ? targetRigidBody.velocity.y * lookAheadMultiplier : 0f);

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
