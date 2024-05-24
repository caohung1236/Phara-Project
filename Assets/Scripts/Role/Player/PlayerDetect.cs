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

    protected override void Start()
    {
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
                Destroy(gameObject);
                Debug.Log("Destroy...");
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
            Destroy(collider2D.gameObject);
            playerShooting.SetActive(true);
            remainingTime = shootingTime;
        }

        if (collider2D.CompareTag("CollectShield"))
        {
            Destroy(collider2D.gameObject);
            isInvincible = true;
            invincibilityTimer = 0;
        }
    }
}
