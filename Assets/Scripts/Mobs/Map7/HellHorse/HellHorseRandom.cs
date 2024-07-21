using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHorseRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 25f;
    protected float rangeY = 2.3f;
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
        Vector3 spawnPos = new(Random.Range(22, rangeX), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newFish = HellHorseSpawner.Instance.Spawn(HellHorseSpawner.hellHorseOne, spawnPos, rotation);
            if (newFish == null) return;
            newFish.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 4f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
