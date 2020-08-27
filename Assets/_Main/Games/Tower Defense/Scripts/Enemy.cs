using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using System;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> Died;

    [SerializeField] private CanvasGroup healthbarCanvasGroup = null;
    [SerializeField] private Image healthbarFillImage = null;

    public int HealthPrediction { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }
    public int Value { get; set; }
    public float MoveSpeed { get; set; }
    public float SlowRecoverySpeed { get; set; }

    private int health;

    private AIPath aiPath;
    private int revealCounter = 0;

    private void Awake()
    {
        GetComponent<AIDestinationSetter>().target = GameObject.Find("Core").transform;
        aiPath = GetComponent<AIPath>();
    }

    private void OnEnable()
    {
        health = MaxHealth;
        HealthPrediction = health;
        revealCounter = 0;

        healthbarFillImage.fillAmount = 1f;
        healthbarCanvasGroup.alpha = 0f;
    }

    private void FixedUpdate()
    {
        if (aiPath.maxSpeed < MoveSpeed)
            aiPath.maxSpeed += SlowRecoverySpeed * Time.deltaTime;
        if (aiPath.maxSpeed > MoveSpeed)
            aiPath.maxSpeed = MoveSpeed;
    }

    public void Reveal()
    {
        revealCounter++;
        if (revealCounter > 0)
            healthbarCanvasGroup.alpha = 1f;
    }

    public void Hide()
    {
        revealCounter--;
        if (revealCounter <= 0)
            healthbarCanvasGroup.alpha = 0f;
    }

    public void TakeDamage(int value)
    {
        health = Mathf.Clamp(health - value, 0, MaxHealth);

        healthbarFillImage.fillAmount = (float)health / (float)MaxHealth;

        if (health <= 0)
        {
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    public void AddSlow(float value, float duration)
    {
        if (aiPath.maxSpeed > MoveSpeed * value)
            aiPath.maxSpeed = MoveSpeed * value;
    }
}
