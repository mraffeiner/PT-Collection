using System.Collections.Generic;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerPrefabs = null;

    public static Tower SelectedTowerDummy { get; set; }

    private void Awake()
    {
        if (SelectedTowerDummy == null)
            SelectedTowerDummy = GameObject.Find("Basic Tower").GetComponent<Tower>();
    }

    public void OnPointerEnter() => SelectedTowerDummy.transform.position = transform.position;

    public void OnPointerExit() => SelectedTowerDummy.transform.localPosition = Vector3.zero;

    public void OnPointerClick()
    {
        SelectedTowerDummy.transform.localPosition = Vector3.zero;

        var towerObject = Instantiate(towerPrefabs.Find(x => x.name == SelectedTowerDummy.name));
        towerObject.transform.position = transform.position;

        gameObject.SetActive(false);
    }
}
