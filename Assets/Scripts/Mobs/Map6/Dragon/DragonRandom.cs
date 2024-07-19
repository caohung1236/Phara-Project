using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 20f;
    protected float rangeY = 2.5f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawnDragon), 15f, 20f);
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void SpawnDragon()
    {
        float spawnPosX = UnityEngine.Random.Range(rangeX, rangeX + rangeX);
        float spawnPosY = UnityEngine.Random.Range(-3f, rangeY);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newDragon = DragonSpawner.Instance.Spawn(DragonSpawner.dragonOne, spawnPos, rotation);
            if (newDragon == null) return;
            newDragon.gameObject.SetActive(true);
            isSpawning = true;
        }
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
