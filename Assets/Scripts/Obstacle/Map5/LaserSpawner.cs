using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : Spawner
{
    private static LaserSpawner instance;
    public static LaserSpawner Instance { get => instance; }
    public static string laserOne = "Laser_1";

    protected override void Awake()
    {
        base.Awake();
        if (LaserSpawner.instance != null)
        {
            Debug.Log("Only 1 LaserSpawner allow to exist");
        }
        LaserSpawner.instance = this;
    }
}
