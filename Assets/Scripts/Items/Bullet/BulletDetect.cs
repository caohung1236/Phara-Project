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
            GameManager.Instance.slimesCount3 += 1;
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

        if (collider2D.CompareTag("EnemyBat"))
        {
            GameManager.Instance.batsCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyCrab"))
        {
            GameManager.Instance.crabCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyFish"))
        {
            GameManager.Instance.fishCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyFly"))
        {
            GameManager.Instance.flyCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyRobot1"))
        {
            GameManager.Instance.robot1Count += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyRobot2"))
        {
            GameManager.Instance.robot2Count += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyRobot3"))
        {
            GameManager.Instance.robot3Count += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyBird"))
        {
            GameManager.Instance.birdsCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyDragon"))
        {
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyBatMonster"))
        {
            GameManager.Instance.batMonstersCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyPhoenix"))
        {
            GameManager.Instance.phoenixCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyHellHorse"))
        {
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyHellDog"))
        {
            GameManager.Instance.hellDogCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyGroundDragon"))
        {
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyMonsterFly"))
        {
            GameManager.Instance.monsterFlyCount += 1;
            HandlerKillEnemy();
        }

        if (collider2D.CompareTag("EnemyDemonFly"))
        {
            GameManager.Instance.demonFlyCount += 1;
            HandlerKillEnemy();
        }
    }

    void HandlerKillEnemy()
    {
        Destroy(gameObject);
        Debug.Log("Destroy...");
    }
}
