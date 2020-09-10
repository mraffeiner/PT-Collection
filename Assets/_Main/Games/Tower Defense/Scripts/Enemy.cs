using UnityEngine;
using UnityEngine.UI;
using System;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> Spawned;
    public static event Action<Enemy> Died;

    [SerializeField] private CanvasGroup healthbarCanvasGroup = null;
    [SerializeField] private Image healthbarFillImage = null;

    public EnemyStats Stats { get; set; }
    public int HealthPrediction { get; set; }

    public float TravelDistancePrediction { get; private set; }

    private AIPath aiPath;
    private int revealCounter = 0;
    private float slowTimer = 0f;

    private int health;
    private int Health
    {
        get => health; set
        {
            health = value;
            healthbarFillImage.fillAmount = (float)Health / (float)Stats.MaxHealth;
        }
    }

    private void Awake()
    {
        GetComponent<AIDestinationSetter>().target = GameObject.Find("Core").transform;
        aiPath = GetComponent<AIPath>();

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Health = Stats.MaxHealth;
        HealthPrediction = Health;

        TravelDistancePrediction = 0f;

        revealCounter = 0;
        healthbarCanvasGroup.alpha = 0f;
        slowTimer = 0f;

        Spawned?.Invoke(this);
    }

    private void Update()
    {
        if (slowTimer > 0f)
            slowTimer -= Time.deltaTime;
        else if (slowTimer <= 0f && aiPath.maxSpeed < Stats.MoveSpeed)
            aiPath.maxSpeed = Mathf.Clamp(aiPath.maxSpeed + Stats.SlowRecoverySpeed * Time.deltaTime, 0f, Stats.MoveSpeed);

        TravelDistancePrediction += aiPath.maxSpeed * Time.deltaTime;
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
        Health = Mathf.Clamp(Health - value, 0, Stats.MaxHealth);

        if (Health <= 0)
        {
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    public void AddSlow(float value, float duration)
    {
        slowTimer = duration;
        aiPath.maxSpeed = Stats.MoveSpeed * value;
    }
}
