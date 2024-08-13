using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : OurMonoBehaviour
{
    private static PlayerMovement instance;
    public static PlayerMovement Instance { get => instance; }
    public float jumpForce;
    [SerializeField] protected bool isFloating = false;
    private Rigidbody2D playerRb;
    public bool isPaused;
    public bool isFlyAnimation = false;
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
    }
    protected virtual void Update()
    {
        if (Time.timeScale == 0)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }

        if (Input.GetMouseButtonDown(0) && isPaused == false)
        {
            Jump();
            PlayerDetect.Instance.isOnGround = false;
            isFlyAnimation = true;
        }
        
        if (isFlyAnimation == true)
        {
            PlayerDetect.Instance.playerAnim.SetFloat("jumpForce", 3);
            isFlyAnimation = false;
        }
    }

    protected virtual void Jump()
    {
        playerRb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
