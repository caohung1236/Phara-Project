using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRandom : OurMonoBehaviour
{
    public GameObject warningObject;
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = -5.5f;
    protected float rangeY = 0f;
    float spawnPosX;
    float spawnPosY;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawnLaser), 20f, 15f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnLaser()
    {
        spawnPosX = rangeX;
        spawnPosY = UnityEngine.Random.Range(rangeY, 5.5f);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newLaser = LaserSpawner.Instance.Spawn(LaserSpawner.laserOne, spawnPos, rotation);
            if (newLaser == null) return;
            newLaser.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 15f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
