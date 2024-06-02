using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : OurMonoBehaviour
{
    public GameObject playerShooting;
    [SerializeField] private float shootingTime = 5.0f;
    [SerializeField] private float remainingTime;
    [SerializeField] private bool isInvincible = false;
    [SerializeField] private float invincibilityTimer = 0f;
    [SerializeField] private float maxInvincibilityTime = 15.0f;
    public ParticleSystem picksItemsParicles;
    private BoxCollider2D myCollider;
    private Rigidbody2D myRigidbody;
    private AudioSource audioSource;
    public AudioClip collectSound;
    public AudioClip playerHitSound;
    public AudioClip footstepSound;

    protected override void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        remainingTime = shootingTime;
    }

    void Update()
    {
        if (playerShooting.activeSelf)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                playerShooting.SetActive(false);
            }
        }

        if (isInvincible)
        {
            invincibilityTimer += Time.deltaTime;

            if (invincibilityTimer >= maxInvincibilityTime)
            {
                isInvincible = false;
                invincibilityTimer = 0;
            }
        }
    }
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {
                Debug.Log("Destroy...");
                audioSource.PlayOneShot(playerHitSound, 1);
                myCollider.enabled = false;
                myRigidbody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                myRigidbody.gravityScale = 50;
                PlayerMovement.Instance.jumpForce = 0;
            }
            else
            {
                Destroy(collider2D.gameObject);
            }
        }

        if (collider2D.CompareTag("Arrow"))
        {
            if (!isInvincible)
            {
                audioSource.PlayOneShot(playerHitSound, 1);
                Destroy(gameObject);
                Destroy(collider2D.gameObject);
                Debug.Log("Destroy...");
            }
            else
            {
                Destroy(collider2D.gameObject);
            }
        }
        
        if (collider2D.CompareTag("CollectBullet"))
        {
            audioSource.PlayOneShot(collectSound, 1f);
            Destroy(collider2D.gameObject);
            playerShooting.SetActive(true);
            remainingTime = shootingTime;
        }

        if (collider2D.CompareTag("CollectShield"))
        {
            audioSource.PlayOneShot(collectSound, 1f);
            Destroy(collider2D.gameObject);
            isInvincible = true;
            invincibilityTimer = 0;
        }

        if (collider2D.CompareTag("CollectGem"))
        {
            audioSource.PlayOneShot(collectSound, 1f);
            Destroy(collider2D.gameObject);
        }
    }

    protected virtual void OnCollisisonEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground") && PlayerMovement.isOnGround)
        {
            Debug.Log("Playing sound...");
            audioSource.PlayOneShot(footstepSound, 1);
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            audioSource.Stop();
        }
    }
}
