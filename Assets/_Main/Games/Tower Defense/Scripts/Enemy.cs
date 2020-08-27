using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using System;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> Died;

    [SerializeField] private EnemyStats stats = null;
    [SerializeField] private CanvasGroup healthbarCanvasGroup = null;
    [SerializeField] private Image healthbarFillImage = null;

    public int Health { get; private set; }
    public int HealthPrediction { get; set; }
    public int Damage => stats.damage;
    public int Value => stats.value;

    private AIPath aiPath;
    private int revealCounter = 0;

    private void Awake()
    {
        GetComponent<AIDestinationSetter>().target = GameObject.Find("Core").transform;
        aiPath = GetComponent<AIPath>();
    }

    private void OnEnable()
    {
        Health = stats.maxHealth;
        HealthPrediction = Health;
        aiPath.maxSpeed = stats.moveSpeed;
        revealCounter = 0;

        healthbarFillImage.fillAmount = 1f;
        healthbarCanvasGroup.alpha = 0f;
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
        Health = Mathf.Clamp(Health - value, 0, stats.maxHealth);

        healthbarFillImage.fillAmount = (float)Health / (float)stats.maxHealth;

        if (Health <= 0)
        {
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
