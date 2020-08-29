using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private bool selectOnAwake = false;
    [SerializeField] private TowerStats towerStats = null;
    [SerializeField] private TextMeshProUGUI costText = null;
    [SerializeField] private TextMeshProUGUI rangeText = null;
    [SerializeField] private TextMeshProUGUI damageText = null;
    [SerializeField] private TextMeshProUGUI reloadText = null;
    [SerializeField] private TextMeshProUGUI splashText = null;
    [SerializeField] private TextMeshProUGUI slowText = null;

    private void Awake()
    {
        if (selectOnAwake)
            GetComponent<Toggle>().isOn = true;
    }

    private void Start()
    {
        costText.text = towerStats.cost.ToString();
    }

    public void SelectTower(Tower towerDummy)
    {
        TowerSlot.SelectedTowerDummy = towerDummy;
        rangeText.text = towerStats.attackRange.ToString();
        damageText.text = towerStats.attackDamage.ToString();
        reloadText.text = Math.Round(1f / towerStats.attacksPerSecond, 2).ToString() + "s";
        splashText.text = towerStats.damageRadius.ToString();
        slowText.text = (towerStats.slowStrength * 100).ToString() + "%";
    }
}
