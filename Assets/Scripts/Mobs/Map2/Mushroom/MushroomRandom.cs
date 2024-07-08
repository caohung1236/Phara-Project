using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 38f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnMushroom();
        }
    }

    protected virtual void SpawnMushroom()
    {
        Vector3 spawnPos = new(Random.Range(30, rangeX), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newMushroom = MushroomSpawner.Instance.Spawn(MushroomSpawner.mushroomOne, spawnPos, rotation);
            if (newMushroom == null) return;
            newMushroom.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 6f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
