using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDragonSpawner : Spawner
{
    private static GroundDragonSpawner instance;

    public static GroundDragonSpawner Instance { get => instance; }

    public static string groundDragonOne = "GroundDragon_1";

    protected override void Awake()
    {
        base.Awake();
        if (GroundDragonSpawner.instance != null)
        {
            Debug.LogError("Only 1 GroundDragonSpawner allow to exist");
        }
        GroundDragonSpawner.instance = this;
    }
}
