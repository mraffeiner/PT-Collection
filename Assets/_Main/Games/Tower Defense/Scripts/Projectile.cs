﻿using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Enemy Target { get; set; }
    public int Damage { get; set; }
    public float DamageRadius { get; set; }
    public float SlowStrength { get; set; }
    public float SlowDuration { get; set; }
    public float Speed { get; set; }

    public SpriteRenderer SpriteRenderer { get; private set; }

    private Core core;
    Vector3 targetPosition = Vector3.zero;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        core = GameObject.FindObjectOfType<Core>();
    }

    private void Start()
    {
        Enemy.Died += OnEnemyRemoved;
        core.EnemyEntered += OnEnemyRemoved;
    }

    private void OnDestroy()
    {
        Enemy.Died -= OnEnemyRemoved;
        core.EnemyEntered -= OnEnemyRemoved;
    }

    private void Update()
    {
        if (Target != null)
            targetPosition = Target.transform.position;

        Move();
    }

    private void Move()
    {
        var vectorToTarget = targetPosition - transform.position;
        var moveVector = (vectorToTarget.normalized * Speed) * Time.deltaTime;

        var distanceBeforeMoving = vectorToTarget.sqrMagnitude;
        var distanceAfterMoving = (targetPosition - (transform.position + moveVector)).sqrMagnitude;

        if (distanceBeforeMoving < .1f || distanceAfterMoving > distanceBeforeMoving)
        {
            DealDamage();
            gameObject.SetActive(false);
        }
        else
            transform.position += moveVector;
    }

    private void DealDamage()
    {
        if (DamageRadius > 0f)
        {
            var hits = Physics2D.OverlapCircleAll(targetPosition, DamageRadius);
            foreach (var hit in hits)
            {
                var enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                    if (SlowStrength > 0f)
                        enemy.AddSlow(1f - SlowStrength, SlowDuration);
                }
            }
        }
        else if (Target != null)
            Target.TakeDamage(Damage);
    }

    private void OnEnemyRemoved(Enemy enemy)
    {
        if (Target == enemy)
            Target = null;
    }
}
