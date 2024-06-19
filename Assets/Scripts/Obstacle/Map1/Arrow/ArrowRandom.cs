using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 12f;
    protected float rangeY = 5.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnArrow();
        }
    }

    protected virtual void SpawnArrow()
    {
        float spawnPosX = UnityEngine.Random.Range(rangeX, rangeX + rangeX);
        float spawnPosY = UnityEngine.Random.Range(2f, rangeY);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newArrow = ArrowSpawner.Instance.Spawn(ArrowSpawner.arrowOne, spawnPos, rotation);
            if (newArrow == null) return;
            newArrow.gameObject.SetActive(true);
            AudioManager.Instance.PlaySFX("ArrowFly");
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 2f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
