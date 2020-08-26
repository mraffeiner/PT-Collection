using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // private void OnApplicationPause(bool pauseStatus) => PlayerPrefs.Save();

    // private void OnDestroy() => PlayerPrefs.Save();

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            Time.timeScale = 1f;
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            Time.timeScale = 2f;
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            Time.timeScale = 3f;
        if (Keyboard.current.rKey.wasPressedThisFrame)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
