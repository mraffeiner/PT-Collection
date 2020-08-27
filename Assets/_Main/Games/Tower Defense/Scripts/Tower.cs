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
    [SerializeField] private bool isDummy = false;

    private Core core;
    private Animator animator;

    private WaitForSeconds waitForCooldown;
    private WaitForSeconds waitForEnemies;
    private List<Enemy> enemiesInRange;
    private Enemy target;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start()
    {
        enemiesInRange = new List<Enemy>();

        rangeTrigger.radius = stats.attackRange;
        rangeLight.pointLightInnerRadius = 0f;
        rangeLight.pointLightOuterRadius = stats.attackRange + 1f;

        if (isDummy)
            animator.enabled = false;
        else
        {
            animator.SetTrigger("Placement");
            StartCoroutine(ShootLoop());
        }
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
            enemy.Hide();
        }
    }

    private IEnumerator ShootLoop()
    {
        while (true)
        {
            do
            {
                if (enemiesInRange.Count < 1)
                    yield return new WaitForSeconds(0.1f);

                UpdateTarget();
            } while (target == null);

            transform.right = target.transform.position - transform.position;

            target.HealthPrediction -= stats.attackDamage;
            animator.SetTrigger("Shoot");
            Shoot?.Invoke(stats, projectileSpawn, target);

            yield return new WaitForSeconds(1f / stats.attacksPerSecond);
        }
    }

    private void UpdateTarget()
    {
        target = enemiesInRange.FirstOrDefault();
        if (target == null)
            return;

        if (target.HealthPrediction <= 0)
        {
            enemiesInRange.Remove(target);
            target = null;
        }
    }
}