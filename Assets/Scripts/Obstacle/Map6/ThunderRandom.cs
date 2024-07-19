using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    public GameObject warningObject;
    protected float rangeX = 0f;
    protected float rangeY = 6.3f;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Warning), 15f);
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
            Transform newThunder = ThunderSpawner.Instance.Spawn(ThunderSpawner.thunderOne, spawnPos, rotation);
            if (newThunder == null) return;
            newThunder.gameObject.SetActive(true);
            isSpawning = true;
        }
        warningObject.SetActive(false);
        Invoke(nameof(ResetSpawning), 20f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }

    protected virtual void Warning()
    {
        Vector3 spawnPos = new(0, 5, 0);
        warningObject.transform.position = spawnPos;
        warningObject.SetActive(true);
        Invoke(nameof(SpawnTide), 3f);
    }
}
