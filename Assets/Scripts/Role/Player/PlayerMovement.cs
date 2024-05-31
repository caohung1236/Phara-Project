using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : OurMonoBehaviour
{
    private static PlayerMovement instance;
    public static PlayerMovement Instance { get => instance; }
    public float jumpForce;
    private float originalGravityScale;
    [SerializeField] protected bool isFloating = false;
    // private bool isOnGround = true;
    private Rigidbody2D playerRb;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerMovement.instance != null)
        {
            Debug.LogError("Only 1 PlayerMovement allow to exist");
        }
        PlayerMovement.instance = this;
    }

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
            // isOnGround = false;
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
        if (transform.parent.position.x < -7)
        {
            transform.parent.position = new Vector3(-7, transform.parent.position.y, transform.parent.position.z);
        }
    }

    protected virtual void Jump()
    {
        playerRb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    // protected virtual void OnCollisisonEnter2D(Collision2D collision2D)
    // {
    //     isOnGround = true;
    // }
}
