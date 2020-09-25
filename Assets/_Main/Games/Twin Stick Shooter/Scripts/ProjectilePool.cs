using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class ProjectilePool : ObjectPoolBase
    {
        private PlayerController player;

        private void Awake() => player = FindObjectOfType<PlayerController>();

        private void OnEnable() => player.Shoot += OnPlayerShot;

        private void OnDisable() => player.Shoot -= OnPlayerShot;

        private void OnPlayerShot(PlayerStats stats, Transform spawnTransform, Transform aimTransform)
        {
            var projectileObject = GetInactiveFromPool();
            var projectileComponent = projectileObject.GetComponent<Projectile>();

            projectileObject.transform.position = spawnTransform.position;
            projectileObject.transform.rotation = aimTransform.rotation;
            projectileComponent.Stats = stats;

            projectileObject.SetActive(true);
        }
    }
}
