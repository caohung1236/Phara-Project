using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGroundDragon : OurMonoBehaviour
{
    public int health;
    private BoxCollider2D boxCollider2D;
    private new Rigidbody2D rigidbody2D;
    protected override void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Bullet"))
        {
            health--;
            if (health == 0)
            {
                boxCollider2D.enabled = false;
                rigidbody2D.constraints = ~RigidbodyConstraints2D.FreezePosition;
                rigidbody2D.AddForce(new Vector2(11, 3), ForceMode2D.Impulse);
                rigidbody2D.gravityScale = 1;
                GameManager.Instance.groundDragonCount += 1;
            }
        }

        if (collider2D.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
