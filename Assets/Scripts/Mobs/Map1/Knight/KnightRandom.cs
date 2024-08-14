using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 25f;
    protected float rangeY = 1.75f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnKnight();
        }
    }

    protected virtual void SpawnKnight()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newKnight = KnightSpawner.Instance.Spawn(KnightSpawner.knightOne, spawnPos, rotation);
            if (newKnight == null) return;
            newKnight.gameObject.SetActive(true);
            isSpawning = true;
        }
        else
        {
            Destroy(gameObject);
        }
        Invoke(nameof(ResetSpawning), 3f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
