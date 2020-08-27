using TMPro;
using UnityEngine;

public class TowerCurrency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText = null;

    public int TotalLights { get; private set; }

    private void Start()
    {
        TotalLights = 20;

        currencyText.text = TotalLights.ToString();
    }
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
    private void OnEnemyDied(Enemy enemy)
    {
        TotalLights += enemy.Value;

        currencyText.text = TotalLights.ToString();
    }

    private void OnTowerBuilt(Tower tower)
    {
        TotalLights -= tower.Cost;

        currencyText.text = TotalLights.ToString();
    }
}
