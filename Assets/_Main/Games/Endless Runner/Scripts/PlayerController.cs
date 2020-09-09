using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer = 0;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpStrength = 10f;
    [SerializeField] private float slideDuration = 1f;
    [SerializeField] private float jumpTimingTolerance = .1f;
    [SerializeField] private float slideTimingTolerance = .2f;

    private Rigidbody2D body;
    private Vector2 newVelocity;
    private bool grounded = false;
    private Vector2 groundNormal;
    private Vector2 groundForward;
    private Coroutine slideRecovery;

    private void Awake() => body = GetComponentInChildren<Rigidbody2D>();

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10f, groundLayer);
        groundForward = new Vector2(hit.normal.y, -hit.normal.x);
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            newVelocity = groundForward * moveSpeed;
        }
        else
            newVelocity = new Vector2(moveSpeed, body.velocity.y);

        body.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            grounded = false;
    }

    public void OnJumpInput()
    {
        if (jumpTimingTolerance > 0f)
            StartCoroutine(ExecuteGroundActionWithTimingTolerance(() => Jump(), jumpTimingTolerance));
        else
            Jump();
    }

    public void OnSlideInput()
    {
        if (slideTimingTolerance > 0f)
            StartCoroutine(ExecuteGroundActionWithTimingTolerance(() => Slide(), slideTimingTolerance));
        else
            Slide();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpStrength);
        grounded = false;
    }

    private void Slide() => slideRecovery = StartCoroutine(RecoverFromSlide());

    private IEnumerator ExecuteGroundActionWithTimingTolerance(Action GroundedAction, float timingTolerance)
    {
        var timer = 0f;
        while (timer < timingTolerance)
        {
            if (grounded && slideRecovery == null)
            {
                GroundedAction();
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator RecoverFromSlide()
    {
        var timer = 0f;
        while (timer < slideDuration)
        {
            timer += Time.deltaTime;
            transform.localEulerAngles = Vector3.back * Vector2.Angle(Vector2.up, groundForward);

            yield return null;
        }

        transform.rotation = Quaternion.identity;
        slideRecovery = null;
    }
}
