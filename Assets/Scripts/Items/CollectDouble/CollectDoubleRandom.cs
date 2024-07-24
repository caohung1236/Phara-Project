using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDoubleRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 38f;
    protected float rangeY = -2f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawnCollectible), 15f, 90f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnCollectible()
    {
        float spawnPosX = rangeX;
        float spawnPosY = Random.Range(rangeY, 5.5f);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newCollect = CollectDoubleSpawner.Instance.Spawn(CollectDoubleSpawner.collectDouble, spawnPos, rotation);
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
