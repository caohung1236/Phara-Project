using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 15f;
    protected float rangeY = 2.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnGround();
        }
    }

    protected virtual void SpawnGround()
    {
        float spawnPosX = UnityEngine.Random.Range(0, rangeX);
        float spawnPosY = UnityEngine.Random.Range(1, rangeY);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        Transform newGround = GroundSpawner.Instance.Spawn(GroundSpawner.groundOne, spawnPos, rotation);
        if (newGround == null) return;
        newGround.gameObject.SetActive(true);
        isSpawning = true;
        Invoke(nameof(ResetSpawning), 8f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
