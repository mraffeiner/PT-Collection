using UnityEngine;

namespace PTCollection.TowerDefense
{
    public class InputHandler : MonoBehaviour
    {
        private InputMaster input;
        private WaveSpawner waveSpawner;
        private SceneController sceneController;

        private void Awake()
        {
            waveSpawner = FindObjectOfType<WaveSpawner>();
            sceneController = FindObjectOfType<SceneController>();

            if (input == null)
                input = new InputMaster();
        }

        private void Start()
        {
            input.TowerDefense.SkipWave.performed += _ => waveSpawner.SkipWave();
            input.TowerDefense.Speedx1.performed += _ => GameSpeed.Factor = 1f;
            input.TowerDefense.Speedx2.performed += _ => GameSpeed.Factor = 2f;
            input.TowerDefense.Speedx3.performed += _ => GameSpeed.Factor = 3f;
            input.TowerDefense.Speedx4.performed += _ => GameSpeed.Factor = 4f;
            input.TowerDefense.Speedx5.performed += _ => GameSpeed.Factor = 5f;

            input.TowerDefense.ReloadScene.performed += _ => sceneController.ReloadCurrentScene();
            input.TowerDefense.ExitToMainMenu.performed += _ => sceneController.FadeAndLoadScene("Main");

            input.UI.Confirm.performed += _ => sceneController.ReloadCurrentScene();
            input.UI.ReloadScene.performed += _ => sceneController.ReloadCurrentScene();
        }

        public void OnEnable() => input.TowerDefense.Enable();

        public void OnDisable() => input.TowerDefense.Disable();

        //TODO: Remove this when there's a master script for input
        private void OnDestroy() => input.Dispose();

        public void SwitchToGameplay()
        {
            input.UI.Disable();
            input.TowerDefense.Enable();
        }

        public void SwitchToUI()
        {
            input.TowerDefense.Disable();
            input.UI.Enable();
        }
    }
}
