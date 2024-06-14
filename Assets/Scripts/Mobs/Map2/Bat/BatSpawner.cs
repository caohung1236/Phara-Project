using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : Spawner
{
    private static BatSpawner instance;
    public static BatSpawner Instance { get => instance; }
    public static string batOne = "Bat_1";

    protected override void Awake()
    {
        base.Awake();
        if (BatSpawner.instance != null)
        {
            Debug.Log("Only 1 BatSpawner allow to exist");
        }
        BatSpawner.instance = this;
    }
}
