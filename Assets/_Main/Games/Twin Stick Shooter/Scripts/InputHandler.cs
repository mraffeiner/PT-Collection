using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class InputHandler : MonoBehaviour
    {
        private InputMaster input;
        private SceneController sceneController;
        private PlayerController playerController;

        private void Awake()
        {
            sceneController = FindObjectOfType<SceneController>();
            playerController = FindObjectOfType<PlayerController>();

            if (input == null)
                input = new InputMaster();
        }

        private void Start()
        {
            input.TwinStickShooter.Move.performed += _ => playerController.OnMoveInput(_);
            input.TwinStickShooter.Move.canceled += _ => playerController.OnMoveInput(_);
            input.TwinStickShooter.Aim.performed += _ => playerController.OnAimInput(_);
            input.TwinStickShooter.Shoot.performed += _ => playerController.OnShootInput();

            input.TwinStickShooter.ReloadScene.performed += _ => sceneController.ReloadCurrentScene();
            input.TwinStickShooter.ExitToMainMenu.performed += _ => sceneController.FadeAndLoadScene("Main");

            input.UI.Confirm.performed += _ => sceneController.ReloadCurrentScene();
            input.UI.ReloadScene.performed += _ => sceneController.ReloadCurrentScene();
        }

        public void OnEnable() => input.TwinStickShooter.Enable();

        public void OnDisable() => input.TwinStickShooter.Disable();

        //TODO: Remove this when there's a master script for input
        private void OnDestroy() => input.Dispose();

        public void SwitchToGameplay()
        {
            input.UI.Disable();
            input.TwinStickShooter.Enable();
        }

        public void SwitchToUI()
        {
            input.TwinStickShooter.Disable();
            input.UI.Enable();
        }
    }
}
