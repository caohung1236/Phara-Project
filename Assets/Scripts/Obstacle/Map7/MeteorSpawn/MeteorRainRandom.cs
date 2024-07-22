using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRainRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 0f;
    protected float rangeY = 1f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Warning), 40f, 40f);
    }

    protected virtual void Update()
    {
    }

    protected virtual void SpawnMeteorRain()
    {
        Vector3 spawnPos = new(rangeX, rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newMeteorRain = MeteorRainSpawner.Instance.Spawn(MeteorRainSpawner.meteorRainOne, spawnPos, rotation);
            if (newMeteorRain == null) return;
            newMeteorRain.gameObject.SetActive(true);
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
        Vector3 spawnPos = new(8, 4, 0);
        warningObject.transform.position = spawnPos;
        warningObject.SetActive(true);
        Invoke(nameof(SpawnMeteorRain), 3f);
    }
}
