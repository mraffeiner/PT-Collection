using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : ObjectPoolBase
{
    [SerializeField] private ObstacleSpawnSettings obstacleSpawnSettings = null;

    private GroundSpawner groundSpawner;
    private List<GameObject> activeObstacles = new List<GameObject>();

    private void Awake() => groundSpawner = FindObjectOfType<GroundSpawner>();

    private void OnEnable()
    {
        groundSpawner.OnWorldRecenter += RecenterObstacles;
        groundSpawner.OnNodeAdded += AddObstaclesToSegment;
        groundSpawner.OnNodeRemoved += RemoveObstaclesFromSegment;
    }

    private void OnDisable()
    {
        groundSpawner.OnWorldRecenter -= RecenterObstacles;
        groundSpawner.OnNodeAdded -= AddObstaclesToSegment;
        groundSpawner.OnNodeRemoved -= RemoveObstaclesFromSegment;
    }

    private void RecenterObstacles(float xShift) => activeObstacles.ForEach(x => x.transform.position -= Vector3.right * xShift);

    private void AddObstaclesToSegment(Vector3 segmentStart, Vector3 segmentEnd)
    {
        var segmentCenter = segmentStart + .5f * (segmentEnd - segmentStart);

        var obstacle = GetInactiveFromPool();
        var obstacleRenderer = obstacle.GetComponent<SpriteRenderer>();

        //TODO: Randomize based on spawn settings
        obstacleRenderer.size = new Vector2(2f, 2f);
        obstacle.transform.position = segmentCenter;

        obstacle.SetActive(true);
        activeObstacles.Add(obstacle);
    }

    private void RemoveObstaclesFromSegment(Vector3 segmentEnd)
    {
        var obstaclesToRemove = activeObstacles.FindAll(x => x.transform.position.x < segmentEnd.x);
        obstaclesToRemove.ForEach(x =>
        {
            x.SetActive(false);
            activeObstacles.Remove(x);
        });
    }
}
