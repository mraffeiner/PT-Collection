using UnityEngine;

namespace PTCollection.EndlessRunner
{
    public class LightPickupSpawner : PooledObjectSpawnerBase
    {
        [SerializeField] private Vector3 spawnOffset = new Vector3(0f, 5f, 0f);

        protected override void RedecoratePooledObject(GameObject pooledObject, Vector3 segmentStart, Vector3 segmentEnd)
        {
            var lightPickup = pooledObject;

            lightPickup.transform.localPosition = segmentStart + spawnOffset;
        }
    }
}
