using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHorseSpawner : Spawner
{
    private static HellHorseSpawner instance;

    public static HellHorseSpawner Instance { get => instance; }

    public static string hellHorseOne = "HellHorse_1";

    protected override void Awake()
    {
        base.Awake();
        if (HellHorseSpawner.instance != null)
        {
            Debug.LogError("Only 1 HellHorseSpawner allow to exist");
        }
        HellHorseSpawner.instance = this;
    }
}
