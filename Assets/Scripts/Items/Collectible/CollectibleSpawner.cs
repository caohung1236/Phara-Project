using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : Spawner
{
    private static CollectibleSpawner instance;
    public static CollectibleSpawner Instance { get => instance; }
    public static string collectOne = "Collect_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectibleSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectibleSpawner allow to exist");
        }
        CollectibleSpawner.instance = this;
    }
}
