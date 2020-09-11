using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Obstacle Spawn Settings")]
public class ObstacleSpawnSettings : ScriptableObject
{
    [Range(2f, 10f)] [SerializeField] private float widthMin = 2f;
    [Range(2f, 10f)] [SerializeField] private float widthMax = 10f;
    [Range(2f, 10f)] [SerializeField] private float heightMin = 2f;
    [Range(2f, 10f)] [SerializeField] private float heightMax = 10f;
    [Range(3f, 10f)] [SerializeField] private float distanceFromGroundMin = 3f;
    [Range(3f, 10f)] [SerializeField] private float distanceFromGroundMax = 10f;

    public float WidthMin => widthMin;
    public float WidthMax => widthMax;
    public float HeightMin => heightMin;
    public float HeightMax => heightMax;
    public float DistanceFromGroundMin => distanceFromGroundMin;
    public float DistanceFromGroundMax => distanceFromGroundMax;
}
