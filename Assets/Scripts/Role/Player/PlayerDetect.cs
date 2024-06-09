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
    private BoxCollider2D myCollider;
    private Rigidbody2D myRigidbody;
    private AudioSource audioSource;
    public AudioClip footstepSound;
    public AudioClip collectSound;
    public AudioClip playerHitSound;
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
        audioSource = GetComponent<AudioSource>();
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

        if (collider2D.CompareTag("Arrow"))
        {
            if (!isInvincible)
            {
                audioSource.PlayOneShot(playerHitSound, 1);
                isGameOver = true;
                shieldEffect.SetActive(false);
                shield.SetActive(false);
                isInvincible = false;
                Destroy(gameObject);
                Destroy(collider2D.gameObject);
                Debug.Log("Destroy...");
            }
            else
            {
                Destroy(collider2D.gameObject);
            }
        }
        
        if (isGameOver == false)
        {
            if (collider2D.CompareTag("CollectBullet"))
            {
                audioSource.PlayOneShot(collectSound, 1f);
                Destroy(collider2D.gameObject);
                playerShooting.SetActive(true);
                bulletEffect.SetActive(true);
                remainingTime = shootingTime;
                particleSystem.Play();
            }

            if (collider2D.CompareTag("CollectShield"))
            {
                audioSource.PlayOneShot(collectSound, 1f);
                Destroy(collider2D.gameObject);
                isInvincible = true;
                shieldEffect.SetActive(true);
                shield.SetActive(true);
                particleSystem.Play();
            }

            if (collider2D.CompareTag("CollectGem"))
            {
                GameManager.Instance.gemsCount += 1;
                audioSource.PlayOneShot(collectSound, 1f);
                Destroy(collider2D.gameObject);
                particleSystem.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            audioSource.clip = footstepSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            audioSource.Stop();
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
                audioSource.PlayOneShot(playerHitSound, 1);
                Debug.Log("Destroy...");
                myCollider.enabled = false;
                myRigidbody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                myRigidbody.gravityScale = 100;
                PlayerMovement.Instance.jumpForce = 0;
                isGameOver = true;
            }
    }
}
