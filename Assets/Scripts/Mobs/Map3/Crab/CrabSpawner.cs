using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : Spawner
{
    private static CrabSpawner instance;

    public static CrabSpawner Instance { get => instance; }

    public static string crabOne = "Crab_1";

    protected override void Awake()
    {
        base.Awake();
        if (CrabSpawner.instance != null)
        {
            Debug.LogError("Only 1 CrabSpawner allow to exist");
        }
        CrabSpawner.instance = this;
    }
}
