using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen = null;

    private EndlessRunnerInputHandler endlessRunnerInput;

    private void Awake() => endlessRunnerInput = FindObjectOfType<EndlessRunnerInputHandler>();

    private void Start() => endlessRunnerInput.enabled = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy" || other.collider.tag == "Obstacle")
            Lose();
    }

    public void Lose()
    {
        endlessRunnerInput.enabled = false;
        gameOverScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
