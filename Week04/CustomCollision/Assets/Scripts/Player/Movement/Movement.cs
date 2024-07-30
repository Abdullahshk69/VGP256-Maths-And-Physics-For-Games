using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Rigidbody2D rb;

    Vector2 moveVelocity;

    bool firstJump;
    bool grounded;

    public void Move(InputAction.CallbackContext context)
    {
        moveVelocity = context.ReadValue<Vector2>();
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

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && grounded)
        {
            firstJump = true;
        }
    }
}
