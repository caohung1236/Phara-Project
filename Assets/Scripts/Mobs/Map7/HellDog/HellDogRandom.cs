using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellDogRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 36f;
    protected float rangeY = 2.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnHellDog();
        }
    }

    protected virtual void SpawnHellDog()
    {
        Vector3 spawnPos = new(Random.Range(33f, rangeX), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newHellDog = HellDogSpawner.Instance.Spawn(HellDogSpawner.hellDogOne, spawnPos, rotation);
            if (newHellDog == null) return;
            newHellDog.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 11.5f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
