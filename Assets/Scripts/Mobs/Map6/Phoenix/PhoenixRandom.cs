using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 22f;
    protected float rangeY = 4f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawnPhoenix), 25f, 20f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnPhoenix()
    {
        float spawnPosX = UnityEngine.Random.Range(rangeX, rangeX + rangeX);
        float spawnPosY = UnityEngine.Random.Range(-3f, rangeY);
        Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newPhoenix = PhoenixSpawner.Instance.Spawn(PhoenixSpawner.phoenixOne, spawnPos, rotation);
            if (newPhoenix == null) return;
            newPhoenix.gameObject.SetActive(true);
            isSpawning = true;
        }
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
