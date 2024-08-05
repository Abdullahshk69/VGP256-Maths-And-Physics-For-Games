using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

enum PlayerState
{
    IDLE,
    RUN,
    JUMP,
    FALL
}

public class Movement : MonoBehaviour, ICollision
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Animator animator;    

    Vector2 moveVelocity;

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity * moveSpeed;
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVelocity = context.ReadValue<Vector2>();
    }

    private void UpdateAnimationState()
    {
        PlayerState state;

        // Player is moving to the right
        if (rb.velocity.x > 0f)
        {
            state = PlayerState.RUN;
            sprite.flipX = false;
        }

        // Player is moving to the left
        else if (rb.velocity.x < 0f)
        {
            state = PlayerState.RUN;
            sprite.flipX = true;
        }

        // Player is idle
        else
        {
            state = PlayerState.IDLE;
        }

        // Player is jumping
        if (rb.velocity.y > 0.1f)
        {
            state = PlayerState.JUMP;
        }

        // Player is falling
        else if (rb.velocity.y < -0.1f)
        {
            state = PlayerState.FALL;
        }

        animator.SetInteger("state", (int)state);
    }

    void ICollision.OnCustomCollisionEnter(Shape shape)
    {
        Debug.Log(shape.gameObject);
        if(shape.gameObject.tag == "Wall" || shape.gameObject.tag == "Door")
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Rectangle rect = (Rectangle)shape;
            Circle circle = GetComponent<Circle>();

            // First check the distance between the center of the circle and the rectangle
            var NearestX = Mathf.Max(rect.V1.x + rect.offset.x, Mathf.Min(circle.Center.x + circle.offset.x, rect.V1.x + rect.offset.x + rect.Width));
            var NearestY = Mathf.Max(rect.V1.y + rect.offset.y, Mathf.Min(circle.Center.y + circle.offset.y, rect.V1.y + rect.offset.y + rect.Height));
            var dist = new Vector2(circle.Center.x + circle.offset.x - NearestX, circle.Center.y + circle.offset.y - NearestY);

            var penetrationDepth = circle.Radius - dist.magnitude;
            var penetrationVector = dist.normalized * penetrationDepth;
            circle.AddDistanceToMove(penetrationVector);
        }
    }

}
