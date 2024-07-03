using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 20f;
    protected float rangeY = 6f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnDragon();
        }
    }

    protected virtual void SpawnDragon()
    {
        float spawnPosX = UnityEngine.Random.Range(rangeX, rangeX + rangeX);
        float spawnPosY = UnityEngine.Random.Range(2f, rangeY);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newDragon = DragonSpawner.Instance.Spawn(DragonSpawner.dragonOne, spawnPos, rotation);
            if (newDragon == null) return;
            newDragon.gameObject.SetActive(true);
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
