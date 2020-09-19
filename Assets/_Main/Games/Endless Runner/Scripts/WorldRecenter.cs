using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

namespace PTCollection.EndlessRunner
{
    public class WorldRecenter : MonoBehaviour
    {
        [SerializeField] private Transform player = null;
        [SerializeField] private Transform cameraParent = null;
        [SerializeField] private SpriteShapeController groundShapeController = null;
        [SerializeField] private Transform resetMarker = null;

        private List<PooledObjectSpawnerBase> spawners;

        private void Awake() => spawners = FindObjectsOfType<PooledObjectSpawnerBase>().ToList();

        private void Update()
        {
            if (player.position.x > resetMarker.position.x)
                MoveWorldToOrigin();
        }

        private void MoveWorldToOrigin()
        {
            var shift = player.position.x;
            var groundSpline = groundShapeController.spline;

            cameraParent.position -= Vector3.right * shift;
            player.position -= Vector3.right * shift;

            for (int i = 0; i < groundSpline.GetPointCount(); i++)
                groundSpline.SetPosition(i, groundSpline.GetPosition(i) - Vector3.right * shift);

            spawners.ForEach(s => s.ActiveObjects.ForEach(o => o.transform.position -= Vector3.right * shift));
        }
    }
}
