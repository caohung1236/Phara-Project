using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2Random : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 32f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SpawnRobot2), 20f);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SpawnRobot2()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        if (PlayerDetect.Instance.isGameOver == false)
        {
            Transform newRobot1 = Robot2Spawner.Instance.Spawn(Robot2Spawner.robotOne, spawnPos, rotation);
            if (newRobot1 == null) return;
            newRobot1.gameObject.SetActive(true);
            isSpawning = true;
        }
        Invoke(nameof(ResetSpawning), 20f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
