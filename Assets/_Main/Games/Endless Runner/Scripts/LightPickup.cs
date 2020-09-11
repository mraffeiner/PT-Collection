using UnityEngine;

public class LightPickup : MonoBehaviour
{
    [SerializeField] private float lightValue = 10;

    private PlayerVision playerVision;

    private void Awake() => playerVision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVision>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerVision.IncreaseVision(lightValue);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
