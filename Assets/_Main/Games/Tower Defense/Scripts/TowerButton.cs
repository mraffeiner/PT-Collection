using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public void SelectTower(Tower towerDummy) => TowerSlot.SelectedTowerDummy = towerDummy;
}
