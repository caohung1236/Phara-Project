using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRobot1Spawner : Spawner
{
    private static BulletRobot1Spawner instance;
    public static BulletRobot1Spawner Instance { get => instance; }
    public static string bulletRobotOne = "BulletRobotOne_1";

    protected override void Awake()
    {
        base.Awake();
        if (BulletRobot1Spawner.instance != null)
        {
            Debug.Log("Only 1 BulletRobot1Spawner allow to exist");
        }
        BulletRobot1Spawner.instance = this;
    }
}
