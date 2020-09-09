using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private bool ignoreX = false;
    [SerializeField] private bool ignoreY = false;
    [SerializeField] private bool ignoreZ = false;

    private Vector3 newPosition = Vector3.zero;

    private void Update()
    {
        newPosition = transform.position;
        if (!ignoreX)
            newPosition.x = target.position.x;
        if (!ignoreY)
            newPosition.y = target.position.y;
        if (!ignoreZ)
            newPosition.z = target.position.z;

        transform.position = newPosition;
    }
}
