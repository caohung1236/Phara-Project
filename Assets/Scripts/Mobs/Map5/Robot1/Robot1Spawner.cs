using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot1Spawner : Spawner
{
    private static Robot1Spawner instance;

    public static Robot1Spawner Instance { get => instance; }

    public static string robotOne = "RobotOne_1";

    protected override void Awake()
    {
        base.Awake();
        if (Robot1Spawner.instance != null)
        {
            Debug.LogError("Only 1 Robot1Spawner allow to exist");
        }
        Robot1Spawner.instance = this;
    }
}
