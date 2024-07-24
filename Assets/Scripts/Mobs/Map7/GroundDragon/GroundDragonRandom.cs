using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDragonRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 30f;
    protected float rangeY = 2.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnGroundDragon();
        }
    }

    protected virtual void SpawnGroundDragon()
    {
        Vector3 spawnPos = new(Random.Range(28, rangeX), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newGroundDragon = GroundDragonSpawner.Instance.Spawn(GroundDragonSpawner.groundDragonOne, spawnPos, rotation);
            if (newGroundDragon == null) return;
            newGroundDragon.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 7f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
