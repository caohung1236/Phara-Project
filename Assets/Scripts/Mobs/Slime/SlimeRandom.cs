using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 20f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnSlime();
        }
    }

    protected virtual void SpawnSlime()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        Transform newSlime = SlimeSpawner.Instance.Spawn(SlimeSpawner.slimeOne, spawnPos, rotation);
        if (newSlime == null) return;
        newSlime.gameObject.SetActive(true);
        isSpawning = true;
        Invoke(nameof(ResetSpawning), 5f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
