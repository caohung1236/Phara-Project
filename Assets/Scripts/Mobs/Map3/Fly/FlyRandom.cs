using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 15f;
    protected float rangeY = 4f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnFly();
        }
    }

    protected virtual void SpawnFly()
    {
        float spawnPosX = UnityEngine.Random.Range(rangeX, rangeX + rangeX);
        float spawnPosY = UnityEngine.Random.Range(2f, rangeY);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        Transform newFly = FlySpawner.Instance.Spawn(FlySpawner.flyOne, spawnPos, rotation);
        if (newFly == null) return;
        newFly.gameObject.SetActive(true);
        isSpawning = true;
        Invoke(nameof(ResetSpawning), 4f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
