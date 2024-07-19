using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDetect : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Bullet"))
        {
            boxCollider2D.enabled = false;
            rigidbody2D.AddForce(new Vector2(15, 5), ForceMode2D.Impulse);
            rigidbody2D.gravityScale = 2;
        }

        if (collider2D.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
