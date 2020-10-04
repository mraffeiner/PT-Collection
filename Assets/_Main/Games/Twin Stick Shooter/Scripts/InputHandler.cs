namespace PTCollection.TwinStickShooter
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
            input.TwinStickShooter.Move.performed += _ => playerController.OnMoveInput(_);
            input.TwinStickShooter.Move.canceled += _ => playerController.OnMoveInput(_);
            input.TwinStickShooter.Aim.performed += _ => playerController.OnAimInput(_);
            input.TwinStickShooter.Shoot.performed += _ => playerController.OnShootInput();
        }

        protected override void EnableGameplay() => input.TwinStickShooter.Enable();

        protected override void DisableGameplay() => input.TwinStickShooter.Disable();
    }
}
