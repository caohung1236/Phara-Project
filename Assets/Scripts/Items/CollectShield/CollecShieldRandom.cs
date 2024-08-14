using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShieldRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 45f;
    protected float rangeY = 2;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawnCollectible), 30f, 35f);

    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnCollectible()
    {
        float spawnPosX = rangeX;
        float spawnPosY = Random.Range(rangeY, 4.5f);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newCollect = CollectShieldSpawner.Instance.Spawn(CollectShieldSpawner.collectShield, spawnPos, rotation);
            if (newCollect == null) return;
            newCollect.gameObject.SetActive(true);
            isSpawning = true;
        }
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
