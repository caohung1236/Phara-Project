using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWavesRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 0f;
    protected float rangeY = 1f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Warning), 20f, 20f);
    }

    protected virtual void Update()
    {
    }

    protected virtual void SpawnWaves()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newWaves = FireWavesSpawner.Instance.Spawn(FireWavesSpawner.fireWavesOne, spawnPos, rotation);
            if (newWaves == null) return;
            newWaves.gameObject.SetActive(true);
            isSpawning = true;
        }
        warningObject.SetActive(false);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }

    protected virtual void Warning()
    {
        Vector3 spawnPos = new(0, -3, 0);
        warningObject.transform.position = spawnPos;
        warningObject.SetActive(true);
        Invoke(nameof(SpawnWaves), 3f);
    }
}
