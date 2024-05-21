using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 50f;
    protected float rangeY = -3.1f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnCollectible();
        }
    }

    protected virtual void SpawnCollectible()
    {
        float spawnPosX = rangeX;
        float spawnPosY = rangeY;
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        Transform newCollect = CollectibleSpawner.Instance.Spawn(CollectibleSpawner.collectOne, spawnPos, rotation);
        if (newCollect == null) return;
        newCollect.gameObject.SetActive(true);
        isSpawning = true;
        Invoke(nameof(ResetSpawning), 30f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
