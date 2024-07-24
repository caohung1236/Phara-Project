using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlyRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 25f;
    protected float rangeY = 5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnMonsterFly();
        }
    }

    protected virtual void SpawnMonsterFly()
    {
        float spawnPosX = UnityEngine.Random.Range(rangeX, rangeX + rangeX);
        float spawnPosY = UnityEngine.Random.Range(3f, rangeY);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newFly = MonsterFlySpawner.Instance.Spawn(MonsterFlySpawner.monsterFlyOne, spawnPos, rotation);
            if (newFly == null) return;
            newFly.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 3f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
