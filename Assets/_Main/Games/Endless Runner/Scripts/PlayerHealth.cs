using UnityEngine;

namespace PTCollection.EndlessRunner
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverScreen = null;

        private InputHandler inputHandler;

        private void Awake() => inputHandler = FindObjectOfType<InputHandler>();

        private void Start() => inputHandler.SwitchToGameplay();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Enemy" || other.collider.tag == "Obstacle")
                Lose();
        }

        public void Lose()
        {
            gameOverScreen.SetActive(true);
            inputHandler.SwitchToUI();

            gameObject.SetActive(false);
        }
    }
}
