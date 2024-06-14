using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletDetect : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("EnemySlime"))
        {
            GameManager.Instance.slimesCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyKnight"))
        {
            GameManager.Instance.knightsCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyGoblin"))
        {
            GameManager.Instance.goblinsCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyMushroom"))
        {
            GameManager.Instance.mushroomsCount += 1;
            HandlerKillEnemy();
        }

        // if (collider2D.CompareTag("EnemyFish"))
        // {
        //     GameManager.Instance.knightsCount += 1;
        //     HandlerKillEnemy();
        // }

        // if (collider2D.CompareTag("EnemyCrab"))
        // {
        //     GameManager.Instance.knightsCount += 1;
        //     HandlerKillEnemy();
        // }
    }

    void HandlerKillEnemy()
    {
        Destroy(gameObject);
        Debug.Log("Destroy...");
    }
}
