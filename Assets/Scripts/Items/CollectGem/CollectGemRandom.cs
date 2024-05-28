using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGemRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 40f;
    protected float rangeY = -2f;
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
        float spawnPosY = Random.Range(rangeY, 3.5f);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        Transform newCollect = CollectGemSpawner.Instance.Spawn(CollectGemSpawner.gemOne, spawnPos, rotation);
        if (newCollect == null) return;
        newCollect.gameObject.SetActive(true);
        isSpawning = true;
        Invoke(nameof(ResetSpawning), 8f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
