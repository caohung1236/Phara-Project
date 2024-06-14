using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : OurMonoBehaviour
{
    public GameObject playerShooting;
    [SerializeField] private float shootingTime = 5.0f;
    [SerializeField] private float remainingTime;
    [SerializeField] private bool isInvincible = false;
    private BoxCollider2D myCollider;
    private Rigidbody2D myRigidbody;
    private static PlayerDetect instance;
    public static PlayerDetect Instance { get => instance; }
    public bool isGameOver = false;
    public bool isOnGround = true;
    public GameObject bulletEffect;
    public GameObject shieldEffect;
    public GameObject shield;
    public GameObject picksItemsParicles;
    public GameObject targetObject;
    private new ParticleSystem particleSystem;
    private GameObject particleSystemInstance;
    public Animator playerAnim;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerDetect.instance != null )
        {
            Debug.LogError("Only 1 PlayerDetect allow to exist");
        }
        PlayerDetect.instance = this;
    }

    protected override void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        remainingTime = shootingTime;
        particleSystemInstance = Instantiate(picksItemsParicles);
        particleSystemInstance.transform.SetParent(targetObject.transform);
        particleSystemInstance.transform.localPosition = Vector2.zero;
        particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (playerShooting.activeSelf)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                bulletEffect.SetActive(false);
                playerShooting.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("EnemySlime"))
        {
            HandlerKillEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyKnight"))
        {
            HandlerKillEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyGoblin"))
        {
            HandlerKillEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyMushroom"))
        {
            HandlerKillEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyFish"))
        {
            HandlerKillEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyCrab"))
        {
            HandlerKillEnemy(collider2D);
        }

        if (collider2D.CompareTag("Arrow"))
        {
            if (isInvincible == true)
            {
                shieldEffect.SetActive(false);
                shield.SetActive(false);
                isInvincible = false;
                Destroy(collider2D.gameObject);
                Debug.Log("Destroy...");
            }
            else
            {
                isGameOver = true;
                AudioManager.Instance.PlaySFX("PlayerHit");
                Destroy(gameObject);
            }
        }

        if (collider2D.CompareTag("Waves"))
        {
            if (isInvincible == true)
            {
                shieldEffect.SetActive(false);
                shield.SetActive(false);
                isInvincible = false;
                Debug.Log("Destroy...");
            }
            else
            {
                isGameOver = true;
                AudioManager.Instance.PlaySFX("PlayerHit");
                Destroy(gameObject);
            }
        }
        
        if (isGameOver == false)
        {
            if (collider2D.CompareTag("CollectBullet"))
            {
                AudioManager.Instance.PlaySFX("Collectable");
                Destroy(collider2D.gameObject);
                playerShooting.SetActive(true);
                bulletEffect.SetActive(true);
                remainingTime = shootingTime;
                particleSystem.Play();
            }

            if (collider2D.CompareTag("CollectShield"))
            {
                AudioManager.Instance.PlaySFX("Collectable");
                Destroy(collider2D.gameObject);
                isInvincible = true;
                shieldEffect.SetActive(true);
                shield.SetActive(true);
                particleSystem.Play();
            }

            if (collider2D.CompareTag("CollectGem"))
            {
                AudioManager.Instance.PlaySFX("Collectable");
                GameManager.Instance.gemsCount += 1;
                Destroy(collider2D.gameObject);
                particleSystem.Play();
            }
        }

        if (collider2D.CompareTag("NPC"))
        {   
            playerAnim.SetTrigger("Idle");
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("NPC"))
        {
            playerAnim.SetTrigger("Run");
        }
    }

    void HandlerKillEnemy(Collider2D collider2D)
    {
        if (isInvincible == true)
        {
            shieldEffect.SetActive(false);
            shield.SetActive(false);
            isInvincible = false;
            Destroy(collider2D.gameObject);
        }
        else
        {
            AudioManager.Instance.PlaySFX("PlayerHit");
            Debug.Log("Destroy...");
            myCollider.enabled = false;
            myRigidbody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            myRigidbody.gravityScale = 100;
            PlayerMovement.Instance.jumpForce = 0;
            isGameOver = true;
        }
    }
}
