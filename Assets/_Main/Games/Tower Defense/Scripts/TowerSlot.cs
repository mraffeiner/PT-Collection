using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public static event Action<Tower> BuildTower;

    [SerializeField] private List<GameObject> towerPrefabs = null;

    public static Tower SelectedTowerDummy { get; set; }

    private TowerCurrency currency;

    private void Awake()
    {
        if (SelectedTowerDummy == null)
            SelectedTowerDummy = GameObject.Find("Tower Strong").GetComponent<Tower>();
        currency = FindObjectOfType<TowerCurrency>();
    }

    public void OnPointerEnter() => SelectedTowerDummy.transform.position = transform.position;

    public void OnPointerExit() => SelectedTowerDummy.transform.localPosition = Vector3.zero;

    public void OnPointerClick()
    {
        if (SelectedTowerDummy.Cost > currency.TotalLights)
        {
            Debug.Log("Not enough lights");
            return;
        }

        SelectedTowerDummy.transform.localPosition = Vector3.zero;

        var towerObject = Instantiate(towerPrefabs.Find(x => x.name == SelectedTowerDummy.name));
        var towerComponent = towerObject.GetComponent<Tower>();

        towerObject.transform.position = transform.position;

        BuildTower?.Invoke(towerComponent);
        gameObject.SetActive(false);
    }
}
