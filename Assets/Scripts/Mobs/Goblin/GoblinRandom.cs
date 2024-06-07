using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 35f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnGoblin();
        }
    }

    protected virtual void SpawnGoblin()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newGoblin = GoblinSpawner.Instance.Spawn(GoblinSpawner.goblinOne, spawnPos, rotation);
            if (newGoblin == null) return;
            newGoblin.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 5f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
