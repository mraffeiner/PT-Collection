using System.Collections.Generic;
using UnityEngine;

public abstract class PooledObjectSpawnerBase : ObjectPoolBase
{
    [SerializeField] private int segmentsBetweenSpawns = 3;

    protected WorldRandomizer randomizer;

    private GroundSpawner groundSpawner;
    private List<GameObject> activeObjects = new List<GameObject>();
    private int segmentsSinceLastSpawn = 0;

    private void Awake()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
        randomizer = FindObjectOfType<WorldRandomizer>();
    }

    private void OnEnable()
    {
        groundSpawner.OnWorldRecenter += RecenterObjects;
        groundSpawner.OnNodeAdded += AddObjectsToSegment;
        groundSpawner.OnNodeRemoved += RemoveObjectsFromSegment;
    }

    private void OnDisable()
    {
        groundSpawner.OnWorldRecenter -= RecenterObjects;
        groundSpawner.OnNodeAdded -= AddObjectsToSegment;
        groundSpawner.OnNodeRemoved -= RemoveObjectsFromSegment;
    }

    protected abstract void RedecoratePooledObject(GameObject pooledObject, Vector3 segmentStart, Vector3 segmentEnd);

    private void RecenterObjects(float xShift) => activeObjects.ForEach(x => x.transform.position -= Vector3.right * xShift);

    private void AddObjectsToSegment(Vector3 segmentStart, Vector3 segmentEnd)
    {
        if (segmentsSinceLastSpawn < segmentsBetweenSpawns)
        {
            segmentsSinceLastSpawn++;
            return;
        }

        segmentsSinceLastSpawn = 0;

        var pooledObject = GetInactiveFromPool();
        RedecoratePooledObject(pooledObject, segmentStart, segmentEnd);

        pooledObject.SetActive(true);
        if (!activeObjects.Contains(pooledObject))
            activeObjects.Add(pooledObject);
    }

    private void RemoveObjectsFromSegment(Vector3 segmentEnd)
    {
        var objectsToRemove = activeObjects.FindAll(x => x.transform.position.x < segmentEnd.x);
        objectsToRemove.ForEach(x =>
        {
            x.SetActive(false);
            activeObjects.Remove(x);
        });
    }

}
