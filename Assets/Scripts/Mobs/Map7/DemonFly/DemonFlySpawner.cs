using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFlySpawner : Spawner
{
    private static DemonFlySpawner instance;

    public static DemonFlySpawner Instance { get => instance; }

    public static string demonFlyOne = "DemonFly_1";

    protected override void Awake()
    {
        base.Awake();
        if (DemonFlySpawner.instance != null)
        {
            Debug.LogError("Only 1 DemonFlySpawner allow to exist");
        }
        DemonFlySpawner.instance = this;
    }
}
