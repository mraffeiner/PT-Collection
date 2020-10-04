using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class Exit : MonoBehaviour
    {
        MapLoader mapLoader;

        private void Awake() => mapLoader = FindObjectOfType<MapLoader>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
                mapLoader.LoadRandomMap();
        }
    }
}
