using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletDetect : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collider2D.gameObject);
            Debug.Log("Destroy...");
        }
    }
}
