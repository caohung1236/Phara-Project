using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellDogSpawner : Spawner
{
    private static HellDogSpawner instance;

    public static HellDogSpawner Instance { get => instance; }

    public static string hellDogOne = "HellDog_1";

    protected override void Awake()
    {
        base.Awake();
        if (HellDogSpawner.instance != null)
        {
            Debug.LogError("Only 1 HellDogSpawner allow to exist");
        }
        HellDogSpawner.instance = this;
    }
}
