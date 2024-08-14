using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 0f;
    protected float rangeY = 2.3f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Warning), 20f, 30f);
    }

    protected virtual void Update()
    {
    }

    protected virtual void SpawnRoots()
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
        Invoke(nameof(SpawnRoots), 3f);
    }
}
