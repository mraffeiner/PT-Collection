using UnityEngine;

public class ObstacleSpawner : PooledObjectSpawnerBase
{
    [SerializeField] private ObstacleSpawnSettings obstacleSpawnSettings = null;

    protected override void RedecoratePooledObject(GameObject pooledObject, Vector3 segmentStart, Vector3 segmentEnd)
    {
        var segmentCenter = segmentStart + .5f * (segmentEnd - segmentStart);

        var obstacle = pooledObject;
        var obstacleRenderer = obstacle.GetComponentInChildren<SpriteRenderer>();
        var obstacleColliderFitter = obstacle.GetComponentInChildren<ColliderFitter>();

        float xSize, ySize, distanceFromGround = 0f;

        // TODO: Safeguard randomness to ensure the obstacle can be cleared

        xSize = randomizer.Range(obstacleSpawnSettings.WidthMin, obstacleSpawnSettings.WidthMax);
        ySize = randomizer.Range(obstacleSpawnSettings.HeightMin, obstacleSpawnSettings.HeightMax);
        distanceFromGround = randomizer.Range(obstacleSpawnSettings.DistanceFromGroundMin, obstacleSpawnSettings.DistanceFromGroundMax);

        obstacleRenderer.size = new Vector2(xSize, ySize);
        obstacleColliderFitter.ApplyFit();
        obstacle.transform.localPosition = segmentCenter + Vector3.up * distanceFromGround;
    }
}
