using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen = null;

    private WaveSpawner waveSpawner;
    private bool blockKeyboardInput;

    private float speedFactor;
    private float SpeedFactor
    {
        get => speedFactor;
        set
        {
            speedFactor = value;
            Time.timeScale = speedFactor;
            Time.fixedDeltaTime = speedFactor * 0.02f;
        }
    }

    private void Awake() => waveSpawner = FindObjectOfType<WaveSpawner>();

    private void Start()
    {
        SpeedFactor = 1f;
        blockKeyboardInput = false;
    }

    private void Update()
    {
        if (!blockKeyboardInput)
            ReadInput();
    }

    private void ReadInput()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            SpeedFactor = 1f;
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SpeedFactor = 2f;
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SpeedFactor = 3f;
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
            SpeedFactor = 4f;
        if (Keyboard.current.digit5Key.wasPressedThisFrame)
            SpeedFactor = 5f;

        if (Keyboard.current.rKey.wasPressedThisFrame)
            ReloadStage();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            waveSpawner.SkipWave();
    }

    public void Lose()
    {
        SpeedFactor = .2f;
        gameOverScreen.SetActive(true);
        blockKeyboardInput = true;
    }

    public void ReloadStage() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
