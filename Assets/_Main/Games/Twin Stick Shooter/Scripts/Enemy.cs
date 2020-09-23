using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

namespace PTCollection.TwinStickShooter
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CanvasGroup healthbarCanvasGroup = null;
        [SerializeField] private Image healthbarFillImage = null;
        [SerializeField] private float moveSpeed = 0f;

        private AIPath aiPath;

        private void Awake() => aiPath = GetComponent<AIPath>();

        private void Start() => aiPath.maxSpeed = moveSpeed;
    }
}
