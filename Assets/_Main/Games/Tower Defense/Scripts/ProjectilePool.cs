using UnityEngine;

public class ProjectilePool : ObjectPoolBase
{
    private void OnEnable() => Tower.Shoot += OnShootEvent;

    private void OnDisable() => Tower.Shoot -= OnShootEvent;

    private void OnShootEvent(TowerStats stats, Transform spawn, Enemy target)
    {
        var projectileObject = GetInactiveFromPool();
        var projectileComponent = projectileObject.GetComponent<Projectile>();

        projectileObject.transform.position = spawn.position;
        projectileObject.transform.rotation = spawn.rotation;

        projectileComponent.SpriteRenderer.sprite = stats.projectileSprite;
        projectileComponent.Target = target;
        projectileComponent.Damage = stats.attackDamage;
        projectileComponent.Speed = stats.projectileSpeed;

        projectileObject.SetActive(true);
    }
}
