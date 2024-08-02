using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    bool firstJump;
    bool grounded;

    

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity * moveSpeed;
        if(firstJump && grounded)
        {
            // jump
            firstJump = false;
        }
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && grounded)
        {
            firstJump = true;
        }
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
        Debug.Log(shape);
    }

}
