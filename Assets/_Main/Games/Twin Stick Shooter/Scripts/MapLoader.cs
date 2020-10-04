using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private List<GameObject> mapPrefabs = new List<GameObject>();

    private Transform player;
    private Transform cameraParent;
    private GameObject currentMap;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        cameraParent = GameObject.Find("Camera Parent").transform;
    }

    private void Start() => LoadRandomMap();

    public void LoadRandomMap()
    {
        if (mapPrefabs.Count <= 0)
            return;

        Destroy(currentMap);

        // Currently only one map available
        // TODO: Actually use world randomizer to pick a random map based on seed
        currentMap = Instantiate(mapPrefabs[0]);

        // Hack for when child order is consistent
        // TODO: Get actual reference to the spawn transforms
        var playerSpawn = currentMap.transform.GetChild(0);
        var cameraSpawn = currentMap.transform.GetChild(1);

        player.position = playerSpawn.position;
        cameraParent.position = cameraSpawn.position;

        AstarPath.active.Scan();
    }
}
