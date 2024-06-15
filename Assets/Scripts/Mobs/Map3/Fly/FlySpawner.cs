using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : Spawner
{
    private static FlySpawner instance;
    public static FlySpawner Instance { get => instance; }
    public static string flyOne = "Fly_1";

    protected override void Awake()
    {
        base.Awake();
        if (FlySpawner.instance != null)
        {
            Debug.Log("Only 1 FlySpawner allow to exist");
        }
        FlySpawner.instance = this;
    }
}
