using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : Spawner
{
    private static MushroomSpawner instance;

    public static MushroomSpawner Instance { get => instance; }

    public static string mushroomOne = "Mushroom_1";

    protected override void Awake()
    {
        base.Awake();
        if (MushroomSpawner.instance != null)
        {
            Debug.LogError("Only 1 MushroomSpawner allow to exist");
        }
        MushroomSpawner.instance = this;
    }
}
