using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TideSpawner : Spawner
{
    private static TideSpawner instance;

    public static TideSpawner Instance { get => instance; }

    public static string tideOne = "Tide_1";

    protected override void Awake()
    {
        base.Awake();
        if (TideSpawner.instance != null)
        {
            Debug.LogError("Only 1 TideSpawner allow to exist");
        }
        TideSpawner.instance = this;
    }
}
