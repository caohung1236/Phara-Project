using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : Spawner
{
    private static FishSpawner instance;

    public static FishSpawner Instance { get => instance; }

    public static string fishOne = "Fish_1";

    protected override void Awake()
    {
        base.Awake();
        if (FishSpawner.instance != null)
        {
            Debug.LogError("Only 1 FishSpawner allow to exist");
        }
        FishSpawner.instance = this;
    }
}
