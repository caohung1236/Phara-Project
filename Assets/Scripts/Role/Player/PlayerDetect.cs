using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : OurMonoBehaviour
{
    public GameObject playerShooting;
    public GameObject playerExplosion;
    [SerializeField] private float shootingTime = 5.0f;
    [SerializeField] private float immortalTime = 5.0f;
    [SerializeField] private float remainingTime;
    [SerializeField] private bool isImmortal = false;
    public bool isInvincible = false;
    private BoxCollider2D myCollider;
    private Rigidbody2D myRigidbody;
    private static PlayerDetect instance;
    public static PlayerDetect Instance { get => instance; }
    public bool isGameOver = false;
    public bool isUseExplosionItem = false;
    public bool isOnGround = true;
    public float countdownTimer = 0f;
    private bool isTutorialText2Active = false;
    public GameObject bulletEffect;
    public GameObject shieldEffect;
    public GameObject explosionEffect;
    public GameObject shield;
    public GameObject explosion;
    public GameObject doubleItems;
    public GameObject picksItemsParticles;
    public GameObject hitEffectParticles;
    public GameObject targetObject;
    public GameObject tutorialText2;
    private new ParticleSystem particleSystem;
    private ParticleSystem hitParticleSystem;
    private GameObject particleSystemInstance;
    private GameObject hitParticleSystemInstance;
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

        particleSystemInstance = Instantiate(picksItemsParticles);
        particleSystemInstance.transform.SetParent(targetObject.transform);
        particleSystemInstance.transform.localPosition = Vector2.zero;
        particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();

        hitParticleSystemInstance = Instantiate(hitEffectParticles);
        hitParticleSystemInstance.transform.SetParent(targetObject.transform);
        hitParticleSystemInstance.transform.localPosition = Vector2.zero;
        hitParticleSystem = hitParticleSystemInstance.GetComponent<ParticleSystem>();
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

        if (isImmortal == true)
        {
            immortalTime -= Time.deltaTime;
            if (immortalTime <= 0)
            {
                isImmortal = false;
                explosion.SetActive(false);
                explosionEffect.SetActive(false);
                PlayerMovement.Instance.jumpForce = 4.5f;
            }
        }

        if (isTutorialText2Active == true)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer <= 0)
            { 
                tutorialText2.SetActive(false);
                isTutorialText2Active = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetFloat("jumpForce", 1f);
        }
        
        if (collision2D.gameObject.CompareTag("Pillar"))
        {
            hitParticleSystem.Play();
            AudioManager.Instance.PlaySFX("PlayerHit");
            myCollider.enabled = false;
            myRigidbody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            myRigidbody.gravityScale = 2;
            PlayerMovement.Instance.jumpForce = 0;
            isGameOver = true;
            Timer.Instance.StopTimer();
        }

        if (collision2D.gameObject.CompareTag("LimitKill"))
        {
            AudioManager.Instance.PlaySFX("PlayerHit");
            isGameOver = true;
        }
    }
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("EnemySlime"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyKnight"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyGoblin"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyMushroom"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyFish"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyCrab"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyRobot1"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyRobot2"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyHellHorse"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyHellDog"))
        {
            HandlerDetectEnemy(collider2D);
        }

        if (collider2D.CompareTag("EnemyGroundDragon"))
        {
            HandlerDetectEnemy(collider2D);
        }





        if (collider2D.CompareTag("Arrow"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyBat"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyFly"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyRobot3"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyBird"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyDragon"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyBatMonster"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyPhoenix"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyMonsterFly"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("EnemyDemonFly"))
        {
            HandlerDetectFly(collider2D);
        }

        if (collider2D.CompareTag("Roots"))
        {
            isGameOver = true;
            AudioManager.Instance.PlaySFX("PlayerHit");
            Destroy(gameObject);
        }

        if (collider2D.CompareTag("Waves"))
        {
            if (isImmortal == true)
            {
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

        if (collider2D.CompareTag("Tide"))
        {
            if (isImmortal == true)
            {
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

        if (collider2D.CompareTag("Laser"))
        {
            if (isImmortal == true)
            {
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

        if (collider2D.CompareTag("Thunder"))
        {
            if (isImmortal == true)
            {
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

        if (collider2D.CompareTag("FireWaves"))
        {
            if (isImmortal == true)
            {
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

        if (collider2D.CompareTag("MeteorRain"))
        {
            if (isImmortal == true)
            {
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
        
        if (collider2D.CompareTag("BulletRobot"))
        {
            if (isInvincible == true || isImmortal == true)
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

            if (collider2D.CompareTag("CollectExplosion"))
            {
                isImmortal = true;
                AudioManager.Instance.PlaySFX("Collectable");
                Destroy(collider2D.gameObject);
                explosionEffect.SetActive(true);
                explosion.SetActive(true);
                particleSystem.Play();
            }

            if (collider2D.CompareTag("CollectDouble"))
            {
                AudioManager.Instance.PlaySFX("Collectable");
                GameManager.Instance.gemsCount6 *= 2;
                GameManager.Instance.gemsCount7 *= 2;
                Destroy(collider2D.gameObject);
                particleSystem.Play();
            }

            if (collider2D.CompareTag("CollectGem"))
            {
                AudioManager.Instance.PlaySFX("Collectable");
                GameManager.Instance.gemsCount += 1;
                GameManager.Instance.gemsCount2 += 1;
                GameManager.Instance.gemsCount3 += 1;
                GameManager.Instance.gemsCount5 += 1;
                GameManager.Instance.gemsCount6 += 0.5f;
                GameManager.Instance.gemsCount7 += 1;
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
            isTutorialText2Active = true;
            tutorialText2.SetActive(true);
        }
    }

    void HandlerDetectEnemy(Collider2D collider2D)
    {
        if (isInvincible == true || isImmortal == true)
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
            myRigidbody.gravityScale = 2;
            PlayerMovement.Instance.jumpForce = 0;
            isGameOver = true;
        }
    }

    void HandlerDetectFly(Collider2D collider2D)
    {
        if (isInvincible == true || isImmortal == true)
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
}
