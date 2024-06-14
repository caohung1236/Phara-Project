using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 0f;
    protected float rangeY = 0.6f;
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
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newRoots = RootsSpawner.Instance.Spawn(RootsSpawner.rootsOne, spawnPos, rotation);
            if (newRoots == null) return;
            newRoots.gameObject.SetActive(true);
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
        Vector3 spawnPos = new(0, -3, 0);
        warningObject.transform.position = spawnPos;
        warningObject.SetActive(true);
        Invoke(nameof(SpawnWaves), 3f);
    }
}
