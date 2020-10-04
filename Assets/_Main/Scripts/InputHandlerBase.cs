using UnityEngine;

namespace PTCollection
{
    public abstract class InputHandlerBase : MonoBehaviour
    {
        protected SceneLoader sceneController;
        protected InputMaster input;

        protected virtual void Awake()
        {
            sceneController = FindObjectOfType<SceneLoader>();

            if (input == null)
                input = new InputMaster();
        }

        private void Start()
        {
            ConfigureUI();
            ConfigureGlobal();
            ConfigureGameplay();

            input.Global.Enable();
        }

        private void OnEnable()
        {
            sceneController.BeforeSceneUnload += DisableAll;
            sceneController.AfterSceneLoad += EnableGameplay;
        }

        private void OnDisable()
        {
            sceneController.BeforeSceneUnload -= DisableAll;
            sceneController.AfterSceneLoad -= EnableGameplay;
        }

        private void OnDestroy() => input.Dispose();

        public void SwitchToGameplay()
        {
            input.UI.Disable();
            EnableGameplay();
        }

        public void SwitchToUI()
        {
            DisableGameplay();
            input.UI.Enable();
        }

        protected abstract void EnableGameplay();

        protected abstract void DisableGameplay();

        protected abstract void ConfigureGameplay();

        private void DisableAll() => input.Disable();

        private void ConfigureUI()
        {
            // Currently only used for game over screen
            // TODO: Replace function call with actual UI element response
            input.UI.Confirm.performed += _ => sceneController.ReloadCurrentScene();
        }

        private void ConfigureGlobal()
        {
            input.Global.ReloadScene.performed += _ => sceneController.ReloadCurrentScene();
            input.Global.ExitToMainMenu.performed += _ => sceneController.FadeAndLoadScene("Main");
        }
    }
}
