using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Tower : MonoBehaviour
{
    public static event Action<TowerStats, Transform, Enemy> Shoot;

    [SerializeField] private TowerStats stats = null;
    [SerializeField] private Transform projectileSpawn = null;
    [SerializeField] private CircleCollider2D rangeTrigger = null;
    [SerializeField] private Light2D rangeLight = null;

    private Core core;
    private WaitForSeconds waitForCooldown;
    private WaitForSeconds waitForEnemies;
    private List<Enemy> enemiesInRange;
    private Enemy target;

    private void Start()
    {
        enemiesInRange = new List<Enemy>();

        rangeTrigger.radius = stats.attackRange;
        rangeLight.pointLightInnerRadius = 0f;
        rangeLight.pointLightOuterRadius = stats.attackRange + .5f;

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
        {
            enemiesInRange.Add(enemy);
            enemy.Reveal();
        }

        if (target == null)
            target = enemiesInRange.FirstOrDefault();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
            enemy.Hide();
        }

        target = enemiesInRange.FirstOrDefault();
    }

    private IEnumerator ShootLoop()
    {
        while (true)
        {
            if (target != null)
            {
                Shoot?.Invoke(stats, projectileSpawn, target);

                target.HealthPrediction -= stats.attackDamage;
                if (target.HealthPrediction <= 0)
                {
                    enemiesInRange.Remove(target);
                    target = enemiesInRange.FirstOrDefault();
                }

                yield return new WaitForSeconds(stats.attackCooldown);
            }
            else
                yield return new WaitForSeconds(.1f);
        }
    }
}