using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : OurMonoBehaviour
{
    [SerializeField] protected float jumpForce;
    [SerializeField] protected bool isFloating = false;
    private float originalGravityScale;
    private Rigidbody2D playerRb;

    protected override void Start()
    {
        base.Start();
        playerRb = transform.parent.GetComponent<Rigidbody2D>();
        originalGravityScale = playerRb.gravityScale;
    }
    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
            isFloating = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFloating = false;
        }

        if (isFloating && playerRb.velocity.y > 0)
        {
            playerRb.gravityScale = 0;
        }
        else
        {
            playerRb.gravityScale = originalGravityScale;
        }
    }

    protected virtual void Jump()
    {
        playerRb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
