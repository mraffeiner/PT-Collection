using TMPro;
using UnityEngine;

public class TowerCurrency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText = null;

    private int totalLights;

    private void Start()
    {
        totalLights = 0;

        currencyText.text = totalLights.ToString();
    }
    private void OnEnable() => Enemy.Die += OnEnemyDied;

    private void OnDisable() => Enemy.Die -= OnEnemyDied;

    private void OnEnemyDied(Enemy enemy)
    {
        totalLights += enemy.Value;

        currencyText.text = totalLights.ToString();
    }
}
