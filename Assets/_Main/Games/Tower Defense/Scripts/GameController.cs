using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen = null;

    private WaveSpawner waveSpawner;

    private void Awake() => waveSpawner = FindObjectOfType<WaveSpawner>();

    private void Start() => Time.timeScale = 1f;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            Time.timeScale = 1f;
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            Time.timeScale = 3f;
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            Time.timeScale = 5f;

        if (Keyboard.current.rKey.wasPressedThisFrame)
            ReloadStage();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            waveSpawner.SkipWave();
    }

    public void Win()
    {

    }

    public void Lose()
    {
        Time.timeScale = .1f;
        gameOverScreen.SetActive(true);
    }

    public void ReloadStage() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
