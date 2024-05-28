using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletDetect : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shootSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(shootSound, 10);
            Destroy(gameObject);
            Debug.Log("Destroy...");
        }
    }
}
