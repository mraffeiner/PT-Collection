using TMPro;
using UnityEngine;

namespace PTCollection.EndlessRunner
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PointTracker : MonoBehaviour
    {
        private Transform player;
        private TextMeshProUGUI textMesh;
        private int pointsPerRecenter = 0;
        private int pointsBackup = 0;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player").transform;
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            // Small hack to prevent point reset when the player gets recentered to world origin
            if (player.transform.position.x < pointsPerRecenter)
                pointsBackup += pointsPerRecenter;

            pointsPerRecenter = (int)player.transform.position.x;
            textMesh.text = (pointsBackup + pointsPerRecenter).ToString();
        }
    }
}
