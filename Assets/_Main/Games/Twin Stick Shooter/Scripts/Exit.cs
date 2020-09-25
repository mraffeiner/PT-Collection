using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class Exit : MonoBehaviour
    {
        SceneController sceneController;

        private void Awake() => sceneController = FindObjectOfType<SceneController>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
                sceneController.ReloadCurrentScene();
        }
    }
}
