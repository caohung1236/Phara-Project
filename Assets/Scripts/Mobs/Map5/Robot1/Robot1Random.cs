using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot1Random : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 15f;
    protected float rangeY = 2.15f;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawnRobot1), 15f, 7f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnRobot1()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newRobot1 = Robot1Spawner.Instance.Spawn(Robot1Spawner.robotOne, spawnPos, rotation);
            if (newRobot1 == null) return;
            newRobot1.gameObject.SetActive(true);
            isSpawning = true;
        }
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
