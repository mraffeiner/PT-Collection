using System;
using TMPro;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private TowerStats towerStats = null;
    [SerializeField] private TextMeshProUGUI costText = null;
    [SerializeField] private TextMeshProUGUI damageText = null;
    [SerializeField] private TextMeshProUGUI rangeText = null;
    [SerializeField] private TextMeshProUGUI reloadText = null;
    [SerializeField] private TextMeshProUGUI slowText = null;

    private void Start() => costText.text = towerStats.cost.ToString();

    public void SelectTower(Tower towerDummy)
    {
        TowerSlot.SelectedTowerDummy = towerDummy;
        damageText.text = towerStats.attackDamage.ToString();
        rangeText.text = towerStats.attackRange.ToString();
        reloadText.text = Math.Round(1f / towerStats.attacksPerSecond, 2).ToString() + "s";
        slowText.text = (towerStats.slowStrength * 100).ToString() + "%";
    }
}
