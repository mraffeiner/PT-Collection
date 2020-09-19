using UnityEngine;

namespace PTCollection.EndlessRunner
{
    [CreateAssetMenu(menuName = "Scriptable Object/Ground Spawn Settings")]
    public class GroundSpawnSettings : ScriptableObject
    {
        [SerializeField] private float groundYMin = 0f;
        [SerializeField] private float groundYMax = 7f;
        [SerializeField] private float splineNodeDistanceMin = 20f;
        [SerializeField] private float splineNodeDistanceMax = 50f;
        [SerializeField] private float tangentLengthMin = 0f;
        [SerializeField] private float tangentLengthMax = 10f;

        public float GroundYMin => groundYMin;
        public float GroundYMax => groundYMax;
        public float SplineNodeDistanceMin => splineNodeDistanceMin;
        public float SplineNodeDistanceMax => splineNodeDistanceMax;
        public float TangentLengthMin => tangentLengthMin;
        public float TangentLengthMax => tangentLengthMax;
    }
}
