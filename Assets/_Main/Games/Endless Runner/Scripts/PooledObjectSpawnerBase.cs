using System.Collections.Generic;
using UnityEngine;

namespace PTCollection.EndlessRunner
{
    public abstract class PooledObjectSpawnerBase : ObjectPoolBase
    {
        [SerializeField] private int segmentsBetweenSpawns = 3;

        protected WorldRandomizer randomizer;

        public List<GameObject> ActiveObjects { get; private set; } = new List<GameObject>();

        private GroundSpawner groundSpawner;
        private int segmentsSinceLastSpawn = 0;

        private void Awake()
        {
            groundSpawner = FindObjectOfType<GroundSpawner>();
            randomizer = FindObjectOfType<WorldRandomizer>();
        }

        private void OnEnable()
        {
            groundSpawner.OnNodeAdded += AddObjectsToSegment;
            groundSpawner.OnNodeRemoved += RemoveObjectsFromSegment;
        }

        private void OnDisable()
        {
            groundSpawner.OnNodeAdded -= AddObjectsToSegment;
            groundSpawner.OnNodeRemoved -= RemoveObjectsFromSegment;
        }

        protected abstract void RedecoratePooledObject(GameObject pooledObject, Vector3 segmentStart, Vector3 segmentEnd);

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
            if (!ActiveObjects.Contains(pooledObject))
                ActiveObjects.Add(pooledObject);
        }

        private void RemoveObjectsFromSegment(Vector3 segmentEnd)
        {
            var objectsToRemove = ActiveObjects.FindAll(x => x.transform.position.x < segmentEnd.x);
            objectsToRemove.ForEach(x =>
            {
                x.SetActive(false);
                ActiveObjects.Remove(x);
            });
        }

    }
}
