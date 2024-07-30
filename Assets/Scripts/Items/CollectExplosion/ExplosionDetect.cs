using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDetect : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("EnemySlime"))
        {
            GameManager.Instance.slimesCount += 1;
        }

        if (collider2D.CompareTag("EnemyCrab"))
        {
            GameManager.Instance.crabCount += 1;
        }

        if (collider2D.CompareTag("EnemyFish"))
        {
            GameManager.Instance.fishCount += 1;
        }

        if (collider2D.CompareTag("EnemyFly"))
        {
            GameManager.Instance.flyCount += 1;
        }

        if (collider2D.CompareTag("EnemyRobot1"))
        {
            GameManager.Instance.robot1Count += 1;
        }

        if (collider2D.CompareTag("EnemyRobot2"))
        {
            GameManager.Instance.robot2Count += 1;
        }

        if (collider2D.CompareTag("EnemyRobot3"))
        {
            GameManager.Instance.robot3Count += 1;
        }

        if (collider2D.CompareTag("EnemyBird"))
        {
            GameManager.Instance.birdsCount += 1;
        }

        if (collider2D.CompareTag("EnemyDragon"))
        {
            GameManager.Instance.dragonsCount += 1;
        }

        if (collider2D.CompareTag("EnemyBatMonster"))
        {
            GameManager.Instance.batMonstersCount += 1;
        }

        if (collider2D.CompareTag("EnemyPhoenix"))
        {
            GameManager.Instance.phoenixCount += 1;
        }

        if (collider2D.CompareTag("EnemyHellHorse"))
        {
            GameManager.Instance.hellHorseCount += 1;
        }

        if (collider2D.CompareTag("EnemyHellDog"))
        {
            GameManager.Instance.hellDogCount += 1;
        }

        if (collider2D.CompareTag("EnemyGroundDragon"))
        {
            GameManager.Instance.groundDragonCount += 1;
        }

        if (collider2D.CompareTag("EnemyMonsterFly"))
        {
            GameManager.Instance.monsterFlyCount += 1;
        }

        if (collider2D.CompareTag("EnemyDemonFly"))
        {
            GameManager.Instance.demonFlyCount += 1;
        }
    }
}
