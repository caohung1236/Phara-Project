using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsSpawner : Spawner
{
    private static RootsSpawner instance;

    public static RootsSpawner Instance { get => instance; }

    public static string rootsOne = "Roots_1";

    protected override void Awake()
    {
        base.Awake();
        if (RootsSpawner.instance != null)
        {
            Debug.LogError("Only 1 RootsSpawner allow to exist");
        }
        RootsSpawner.instance = this;
    }
}
