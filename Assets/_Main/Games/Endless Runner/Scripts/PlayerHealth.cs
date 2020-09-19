using UnityEngine;

namespace PTCollection.EndlessRunner
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverScreen = null;

        private InputHandler endlessRunnerInput;

        private void Awake() => endlessRunnerInput = FindObjectOfType<InputHandler>();

        private void Start() => endlessRunnerInput.SwitchToGameplay();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Enemy" || other.collider.tag == "Obstacle")
                Lose();
        }

        public void Lose()
        {
            gameOverScreen.SetActive(true);
            endlessRunnerInput.SwitchToUI();

            gameObject.SetActive(false);
        }
    }
}
