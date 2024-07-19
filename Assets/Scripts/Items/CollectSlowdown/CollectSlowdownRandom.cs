using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSlowdownRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 36f;
    protected float rangeY = -2f;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SpawnCollectible), 20f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnCollectible()
    {
        float spawnPosX = rangeX;
        float spawnPosY = Random.Range(rangeY, 3.5f);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newCollect = CollectSlowdownSpawner.Instance.Spawn(CollectSlowdownSpawner.collectSlowdown, spawnPos, rotation);
            if (newCollect == null) return;
            newCollect.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 20f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
