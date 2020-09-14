using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 lookAhead = Vector3.zero;
    [SerializeField] private float smoothTime = 0f;
    [SerializeField] private bool ignoreX = false;
    [SerializeField] private bool ignoreY = false;
    [SerializeField] private bool ignoreZ = false;

    private Vector3 newPosition = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        newPosition = transform.position;
        if (!ignoreX)
            newPosition.x = target.position.x + lookAhead.x;
        if (!ignoreY)
            newPosition.y = target.position.y + lookAhead.y;
        if (!ignoreZ)
            newPosition.z = target.position.z + lookAhead.z;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
