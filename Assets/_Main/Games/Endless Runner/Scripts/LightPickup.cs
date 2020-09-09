using UnityEngine;
using UnityEngine.Events;

public class LightPickup : MonoBehaviour
{
    [SerializeField] private UnityEvent OnLightPickedUp = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            OnLightPickedUp.Invoke();
    }
}
