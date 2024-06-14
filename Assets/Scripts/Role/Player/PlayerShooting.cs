using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1.0f;
    [SerializeField] protected float shootTimer = 0.0f;
    void Update()
    {
        //IsShooting();
        Shooting();
    }

    protected virtual void Shooting()
    {
        //if (!isShooting) return;
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        AudioManager.Instance.PlaySFX("BulletSound");
        Debug.Log("Shooting...");
    }

    protected virtual bool IsShooting()
    {
        isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}
