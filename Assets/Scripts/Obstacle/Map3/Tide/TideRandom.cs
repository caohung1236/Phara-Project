using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TideRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 0f;
    protected float rangeY = 2f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Warning), 15f, 25f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnTide()
    {
        Vector3 spawnPos = new(rangeX, rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newTide = TideSpawner.Instance.Spawn(TideSpawner.tideOne, spawnPos, rotation);
            if (newTide == null) return;
            newTide.gameObject.SetActive(true);
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
        Invoke(nameof(SpawnTide), 3f);
    }
}
