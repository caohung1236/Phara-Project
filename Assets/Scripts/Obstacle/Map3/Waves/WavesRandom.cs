using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 1f;
    protected float rangeY = 1f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Warning), 25f, 35f);
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
