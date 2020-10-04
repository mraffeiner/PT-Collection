namespace PTCollection.TowerDefense
{
    public class InputHandler : InputHandlerBase
    {
        private WaveSpawner waveSpawner;

        protected override void Awake()
        {
            base.Awake();
            waveSpawner = FindObjectOfType<WaveSpawner>();
        }

        protected override void ConfigureGameplay()
        {
            input.TowerDefense.SkipWave.performed += _ => waveSpawner.SkipWave();
            input.TowerDefense.Speedx1.performed += _ => GameSpeed.Factor = 1f;
            input.TowerDefense.Speedx2.performed += _ => GameSpeed.Factor = 2f;
            input.TowerDefense.Speedx3.performed += _ => GameSpeed.Factor = 3f;
            input.TowerDefense.Speedx4.performed += _ => GameSpeed.Factor = 4f;
            input.TowerDefense.Speedx5.performed += _ => GameSpeed.Factor = 5f;
        }

        protected override void EnableGameplay() => input.TowerDefense.Enable();

        protected override void DisableGameplay() => input.TowerDefense.Disable();
    }
}
