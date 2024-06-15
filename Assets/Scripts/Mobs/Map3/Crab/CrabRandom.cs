using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrabRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 39f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SpawnCrab), 5f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnCrab()
    {
        Vector3 spawnPos = new(Random.Range(36.5f, rangeX), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newCrab = CrabSpawner.Instance.Spawn(CrabSpawner.crabOne, spawnPos, rotation);
            if (newCrab == null) return;
            newCrab.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 12f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
