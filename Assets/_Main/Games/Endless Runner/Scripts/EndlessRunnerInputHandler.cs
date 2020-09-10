using UnityEngine;

public class EndlessRunnerInputHandler : MonoBehaviour
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
        input.EndlessRunner.Jump.performed += _ => playerController.OnJumpInput();
        input.EndlessRunner.Slide.performed += _ => playerController.OnSlideInput();

        input.EndlessRunner.ReloadScene.performed += _ => sceneController.ReloadCurrentScene();
        input.EndlessRunner.ExitToMainMenu.performed += _ => sceneController.LoadScene("Main");
    }

    public void OnEnable() => input.EndlessRunner.Enable();

    public void OnDisable() => input.EndlessRunner.Disable();

    //TODO: Remove this when there's a master script for input
    private void OnDestroy() => input.Dispose();
}
