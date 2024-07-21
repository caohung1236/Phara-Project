using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 30f;
    protected float rangeY = 3.2f;
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
        Vector3 spawnPos = new(Random.Range(rangeX, 32), -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newSlime = SlimeSpawner.Instance.Spawn(SlimeSpawner.slimeOne, spawnPos, rotation);
            if (newSlime == null) return;
            newSlime.gameObject.SetActive(true);
            isSpawning = true;
        }
        else
        {
            Destroy(gameObject);
        }
        Invoke(nameof(ResetSpawning), 5f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
