using System.Collections.Generic;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerPrefabs = null;
    [SerializeField] private GameObject selectedTowerDummy = null;

    public void OnPointerEnter() => selectedTowerDummy.transform.position = transform.position;

    public void OnPointerExit() => selectedTowerDummy.transform.localPosition = Vector3.zero;

    public void OnPointerClick()
    {
        selectedTowerDummy.transform.localPosition = Vector3.zero;

        var towerObject = Instantiate(towerPrefabs.Find(x => x.name == selectedTowerDummy.name));
        towerObject.transform.position = transform.position;

        gameObject.SetActive(false);
    }
}
