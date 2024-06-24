using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot3Spawner : Spawner
{
    private static Robot3Spawner instance;
    public static Robot3Spawner Instance { get => instance; }
    public static string robotOne = "RobotThree_1";

    protected override void Awake()
    {
        base.Awake();
        if (Robot3Spawner.instance != null)
        {
            Debug.Log("Only 1 Robot3Spawner allow to exist");
        }
        Robot3Spawner.instance = this;
    }
}
