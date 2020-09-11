using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PointTracker : MonoBehaviour
{
    private Transform player;
    private TextMeshProUGUI textMesh;
    private int pointsTotal = 0;
    private int pointsBackup = 0;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Small hack to prevent point reset when the player gets recentered to world origin
        if (player.transform.position.x < pointsTotal)
            pointsBackup = pointsTotal;

        pointsTotal = (int)player.transform.position.x;
        textMesh.text = (pointsBackup + pointsTotal).ToString();
    }
}
