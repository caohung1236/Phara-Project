using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 4f;
    protected float rangeY = 2.5f;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Warning), 25f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnWaves()
    {
        Vector3 spawnPos = new(-rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newWaves = WavesSpawner.Instance.Spawn(WavesSpawner.wavesOne, spawnPos, rotation);
            if (newWaves == null) return;
            newWaves.gameObject.SetActive(true);
            isSpawning = true;
        }
        warningObject.SetActive(false);
        Invoke(nameof(ResetSpawning), 30f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }

    protected virtual void Warning()
    {
        Vector3 spawnPos = new(-6, -3, 0);
        warningObject.transform.position = spawnPos;
        warningObject.SetActive(true);
        Invoke(nameof(SpawnWaves), 3f);
    }
}
