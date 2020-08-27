using UnityEngine;

public class ProjectilePool : ObjectPoolBase
{
    private void OnEnable() => Tower.Fired += OnTowerFired;

    private void OnDisable() => Tower.Fired -= OnTowerFired;

    private void OnTowerFired(TowerStats stats, Transform spawn, Enemy target)
    {
        var projectileObject = GetInactiveFromPool();
        var projectileComponent = projectileObject.GetComponent<Projectile>();

        projectileObject.transform.position = spawn.position;
        projectileObject.transform.rotation = spawn.rotation;

        projectileComponent.SpriteRenderer.color = stats.projectileColor;
        projectileComponent.Target = target;
        projectileComponent.Damage = stats.attackDamage;
        projectileComponent.Speed = stats.projectileSpeed;

        projectileObject.SetActive(true);
    }
}
