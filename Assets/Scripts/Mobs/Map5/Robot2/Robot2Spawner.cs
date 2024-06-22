using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2Spawner : Spawner
{
    private static Robot2Spawner instance;

    public static Robot2Spawner Instance { get => instance; }

    public static string robotOne = "RobotTwo_1";

    protected override void Awake()
    {
        base.Awake();
        if (Robot2Spawner.instance != null)
        {
            Debug.LogError("Only 1 Robot2Spawner allow to exist");
        }
        Robot2Spawner.instance = this;
    }
}
