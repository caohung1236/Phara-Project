using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawner : Spawner
{
    private static DragonSpawner instance;
    public static DragonSpawner Instance { get => instance; }
    public static string dragonOne = "Dragon_1";

    protected override void Awake()
    {
        base.Awake();
        if (DragonSpawner.instance != null)
        {
            Debug.Log("Only 1 DragonSpawner allow to exist");
        }
        DragonSpawner.instance = this;
    }
}
