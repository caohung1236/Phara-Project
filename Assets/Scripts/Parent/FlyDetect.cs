using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
