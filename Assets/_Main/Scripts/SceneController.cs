using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ReloadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void Exit() => Application.Quit();
}
