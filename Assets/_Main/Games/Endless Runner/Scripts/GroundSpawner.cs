using System;
using UnityEngine;
using UnityEngine.U2D;

public class GroundSpawner : MonoBehaviour
{
    public event Action<float> OnWorldRecenter;
    public event Action<Vector3, Vector3> OnNodeAdded;
    public event Action<Vector3> OnNodeRemoved;

    [SerializeField] private Transform player = null;
    [SerializeField] private SpriteShapeController spriteShapeController = null;
    [SerializeField] private GroundSpawnSettings groundSpawnSettings = null;

    private WorldRandomizer randomizer;
    private Spline groundSpline;

    private float LastSplineNodeX => groundSpline.GetPosition(groundSpline.GetPointCount() - 1).x;
    private float FirstSplineNodeX => groundSpline.GetPosition(0).x;

    private void Awake() => randomizer = FindObjectOfType<WorldRandomizer>();

    private void Start()
    {
        groundSpline = spriteShapeController.spline;

        // Add a node at the beginning to prevent falling through the floor on the first trigger
        GrowSplineFront();
    }

    private void Update()
    {
        if (player.position.x > 1000f)
            RecenterWorld();

        if (player.position.x > LastSplineNodeX - groundSpawnSettings.SplineNodeDistanceMax * 3f)
            GrowSplineFront();

        if (player.position.x > FirstSplineNodeX + groundSpawnSettings.SplineNodeDistanceMax * 3f)
            ShrinkSplineBack();
    }

    private void RecenterWorld()
    {
        var xShift = player.position.x;

        player.position -= Vector3.right * xShift;

        for (int i = 0; i < groundSpline.GetPointCount(); i++)
            groundSpline.SetPosition(i, groundSpline.GetPosition(i) - Vector3.right * xShift);

        OnWorldRecenter?.Invoke(xShift);
    }

    private void GrowSplineFront()
    {
        var i = groundSpline.GetPointCount() - 1;

        var y = randomizer.Range(groundSpawnSettings.GroundYMin, groundSpawnSettings.GroundYMax);
        var leftTangent = Quaternion.identity * Vector3.left * randomizer.Range(groundSpawnSettings.TangentLengthMin, groundSpawnSettings.TangentLengthMax);
        var rightTangent = Quaternion.identity * Vector3.right * randomizer.Range(groundSpawnSettings.TangentLengthMin, groundSpawnSettings.TangentLengthMax);
        var distance = randomizer.Range(groundSpawnSettings.SplineNodeDistanceMin, groundSpawnSettings.SplineNodeDistanceMax);

        // We can't append at the end, so we move the last node ahead and insert a new one at its x position
        groundSpline.SetPosition(i, groundSpline.GetPosition(i) + Vector3.right * distance);

        groundSpline.InsertPointAt(i, new Vector3(LastSplineNodeX, y, 0f));
        groundSpline.SetTangentMode(i, ShapeTangentMode.Continuous);
        groundSpline.SetLeftTangent(i, leftTangent);
        groundSpline.SetRightTangent(i, rightTangent);

        OnNodeAdded?.Invoke(groundSpline.GetPosition(i - 1), groundSpline.GetPosition(i));
    }

    private void ShrinkSplineBack()
    {
        groundSpline.RemovePointAt(0);

        OnNodeRemoved?.Invoke(groundSpline.GetPosition(0));
    }

}
