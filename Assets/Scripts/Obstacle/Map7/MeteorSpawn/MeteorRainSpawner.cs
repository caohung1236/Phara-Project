using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRainSpawner : Spawner
{
    private static MeteorRainSpawner instance;

    public static MeteorRainSpawner Instance { get => instance; }

    public static string meteorRainOne = "MeteorRain_1";

    protected override void Awake()
    {
        base.Awake();
        if (MeteorRainSpawner.instance != null)
        {
            Debug.LogError("Only 1 MeteorRainSpawner allow to exist");
        }
        MeteorRainSpawner.instance = this;
    }
}
