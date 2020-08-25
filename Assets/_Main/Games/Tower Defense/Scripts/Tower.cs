using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static event Action<TowerStats, Transform, Enemy> Shoot;

    [SerializeField] private TowerStats stats = null;
    [SerializeField] private Transform projectileSpawn = null;

    private WaitForSeconds waitForCooldown;
    private WaitForSeconds waitForEnemies;
    private List<Enemy> enemiesInRange;
    private Enemy target;

    private void Start()
    {
        enemiesInRange = new List<Enemy>();

        var collider = GetComponent<CircleCollider2D>();
        collider.radius = stats.attackRange;

        StartCoroutine(ShootLoop());
    }

    private void Update()
    {
        if (target != null)
            transform.right = target.transform.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
            enemiesInRange.Add(enemy);

        if (target == null)
            target = enemiesInRange.FirstOrDefault();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
            enemiesInRange.Remove(enemy);

        target = enemiesInRange.FirstOrDefault();
    }

    private IEnumerator ShootLoop()
    {
        while (true)
        {
            if (target != null)
            {
                Shoot?.Invoke(stats, projectileSpawn, target);

                yield return new WaitForSeconds(stats.attackCooldown);
            }
            else
                yield return new WaitForSeconds(.1f);
        }
    }
}