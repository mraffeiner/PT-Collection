using UnityEngine;

namespace PTCollection
{
    public class SceneReaction : MonoBehaviour
    {
        private SceneController sceneController;

        private void Awake() => sceneController = FindObjectOfType<SceneController>();

        public void LoadScene(string sceneName) => sceneController.FadeAndLoadScene(sceneName);
    }
}
