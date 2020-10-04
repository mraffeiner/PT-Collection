namespace PTCollection.EndlessRunner
{
    public class InputHandler : InputHandlerBase
    {
        private PlayerController playerController;

        protected override void Awake()
        {
            base.Awake();
            playerController = FindObjectOfType<PlayerController>();
        }

        protected override void ConfigureGameplay()
        {
            input.EndlessRunner.Jump.performed += _ => playerController.OnJumpInput();
            input.EndlessRunner.Slide.performed += _ => playerController.OnSlideInput();
        }

        protected override void EnableGameplay() => input.EndlessRunner.Enable();

        protected override void DisableGameplay() => input.EndlessRunner.Disable();
    }
}
