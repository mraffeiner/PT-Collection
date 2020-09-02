using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Tower : MonoBehaviour
{
    public static event Action<TowerStats, Transform, Enemy> Fired;

    [SerializeField] private TowerStats stats = null;
    [SerializeField] private CircleCollider2D rangeTrigger = null;
    [SerializeField] private Light2D rangeLight = null;
    [SerializeField] private bool isDummy = false;

    public int Cost => stats.Cost;

    private Core core;
    private GameObject towerTooltip;
    private Animator animator;
    private List<Enemy> enemiesInRange;
    private Enemy target;
    private bool hovering = false;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start()
    {
        rangeLight.pointLightInnerRadius = 0f;
        rangeLight.pointLightOuterRadius = stats.AttackRange + 1f;

        if (isDummy)
        {
            enabled = false;
            return;
        }

        enemiesInRange = new List<Enemy>();
        rangeTrigger.radius = stats.AttackRange;

        towerTooltip = GameObject.Find("World Canvas").transform.Find("Tower Tooltip").gameObject;

        animator.SetTrigger("Placement");
        StartCoroutine(ShootLoop());
    }

    private void Update() => UpdateTooltip();

    private void UpdateTooltip()
    {
        if (towerTooltip == null || !hovering)
            return;

        towerTooltip.transform.position = transform.position + new Vector3(1f, 1f);
        towerTooltip.SetActive(true);
    }

    public void OnPointerEnter()
    {
        if (!towerTooltip.activeSelf)
            hovering = true;
    }

    public void OnPointerExit()
    {
        hovering = false;
        towerTooltip.SetActive(false);
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

            target.HealthPrediction -= stats.AttackDamage;
            animator.SetTrigger("Shoot");
            Fired?.Invoke(stats, transform, target);

            yield return new WaitForSeconds(1f / stats.AttacksPerSecond);
        }
    }

    private void UpdateTarget()
    {
        target = enemiesInRange.OrderBy(x => x.TravelDistancePrediction).LastOrDefault();
        if (target == null)
            return;

        if (target.HealthPrediction <= 0)
        {
            enemiesInRange.Remove(target);
            target = null;
        }
    }
}