using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : MonoBehaviour
{
    public GameObject playerShooting;
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Destroy...");
        }

        if (collider2D.CompareTag("Arrow"))
        {
            Destroy(gameObject);
            Destroy(collider2D.gameObject);
        }

        if (collider2D.CompareTag("Collectible"))
        {
            Destroy(collider2D.gameObject);
            playerShooting.gameObject.SetActive(true);
        }
    }
}
