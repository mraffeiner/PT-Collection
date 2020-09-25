using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace PTCollection.TwinStickShooter
{
    public class PlayerController : MonoBehaviour
    {
        public event Action<PlayerStats, Transform, Transform> Shoot;

        [SerializeField] private PlayerStats stats = null;
        [SerializeField] private Transform aimRoot = null;
        [SerializeField] private Transform projectileSpawn = null;

        private Camera mainCam;
        private Rigidbody2D body;
        private Vector2 moveVector = Vector2.zero;
        private Vector2 aimScreenPosition = Vector2.zero;
        private float attackCooldownTimer = 0f;

        private void Awake()
        {
            mainCam = Camera.main;
            body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (attackCooldownTimer > 0f)
                attackCooldownTimer -= Time.deltaTime;
        }

        private void FixedUpdate()
        {
            body.MovePosition(body.position + moveVector * stats.MoveSpeed * Time.deltaTime);
            aimRoot.right = (Vector2)mainCam.ScreenToWorldPoint(aimScreenPosition) - (Vector2)transform.position; ;
        }

        public void OnMoveInput(CallbackContext ctx) => moveVector = ctx.ReadValue<Vector2>();

        public void OnAimInput(CallbackContext ctx) => aimScreenPosition = ctx.ReadValue<Vector2>();

        public void OnShootInput()
        {
            if (attackCooldownTimer > 0f)
                return;

            attackCooldownTimer = stats.AttackCooldown;
            Shoot?.Invoke(this.stats, projectileSpawn, aimRoot);
        }
    }
}
