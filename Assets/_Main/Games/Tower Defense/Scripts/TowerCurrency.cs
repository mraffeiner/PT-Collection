using TMPro;
using UnityEngine;

public class TowerCurrency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText = null;
    [SerializeField] private int startAmount = 20;

    private int totalLights;
    public int TotalLights
    {
        get => totalLights; private set
        {
            totalLights = value;
            currencyText.text = totalLights.ToString();
        }
    }

    private void Start() => TotalLights = startAmount;
    private void OnEnable()
    {
        Enemy.Died += OnEnemyDied;
        TowerSlot.BuildTower += OnTowerBuilt;
    }
    private void OnDisable()
    {
        Enemy.Died -= OnEnemyDied;
        TowerSlot.BuildTower -= OnTowerBuilt;
    }
    private void OnEnemyDied(Enemy enemy) => TotalLights += enemy.Stats.Value;

    private void OnTowerBuilt(Tower tower) => TotalLights -= tower.Cost;
}
