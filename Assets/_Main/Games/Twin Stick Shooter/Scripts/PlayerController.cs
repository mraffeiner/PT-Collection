using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace PTCollection.TwinStickShooter
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform aimIndicator = null;
        [SerializeField] private float moveSpeed = 10f;

        private Camera mainCam;
        private Rigidbody2D body;
        private Vector2 moveVector = Vector2.zero;
        private Vector2 aimScreenPosition = Vector2.zero;

        private void Awake()
        {
            mainCam = Camera.main;
            body = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            body.MovePosition(body.position + moveVector * moveSpeed * Time.deltaTime);
            aimIndicator.right = (Vector2)mainCam.ScreenToWorldPoint(aimScreenPosition) - (Vector2)transform.position; ;
        }
        public void OnMoveInput(CallbackContext ctx) => moveVector = ctx.ReadValue<Vector2>();

        public void OnAimInput(CallbackContext ctx) => aimScreenPosition = ctx.ReadValue<Vector2>();
    }
}
