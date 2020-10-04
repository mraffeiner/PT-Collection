using UnityEngine;

namespace PTCollection
{
    public class SceneReaction : MonoBehaviour
    {
        private SceneLoader sceneController;

        private void Awake() => sceneController = FindObjectOfType<SceneLoader>();

        public void LoadScene(string sceneName) => sceneController.FadeAndLoadScene(sceneName);

        // TODO: This is dumb, make an actual game manager or sth
        public void Exit() => sceneController.Exit();
    }
}
