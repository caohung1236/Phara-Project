using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRobot2Spawner : Spawner
{
    private static BulletRobot2Spawner instance;
    public static BulletRobot2Spawner Instance { get => instance; }
    public static string bulletRobotTwo = "BulletRobotTwo_1";

    protected override void Awake()
    {
        base.Awake();
        if (BulletRobot2Spawner.instance != null)
        {
            Debug.Log("Only 1 BulletRobot2Spawner allow to exist");
        }
        BulletRobot2Spawner.instance = this;
    }
}
