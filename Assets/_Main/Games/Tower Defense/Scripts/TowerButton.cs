using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PTCollection.TowerDefense
{
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
            costText.text = towerStats.Cost.ToString();
        }

        public void SelectTower(Tower towerDummy)
        {
            TowerSlot.SelectedTowerDummy = towerDummy;
            rangeText.text = towerStats.AttackRange.ToString();
            damageText.text = towerStats.AttackDamage.ToString();
            reloadText.text = Math.Round(1f / towerStats.AttacksPerSecond, 2).ToString() + "s";
            splashText.text = towerStats.DamageRadius.ToString();
            slowText.text = (towerStats.SlowStrength * 100).ToString() + "%";
        }
    }
}
