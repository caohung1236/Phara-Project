using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 42f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnFish();
        }
    }

    protected virtual void SpawnFish()
    {
        Vector3 spawnPos = new(Random.Range(39.5f, rangeX), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newFish = FishSpawner.Instance.Spawn(FishSpawner.fishOne, spawnPos, rotation);
            if (newFish == null) return;
            newFish.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 8f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
