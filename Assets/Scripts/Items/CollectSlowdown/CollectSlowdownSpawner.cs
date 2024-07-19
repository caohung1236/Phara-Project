using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSlowdownSpawner : Spawner
{
    private static CollectSlowdownSpawner instance;
    public static CollectSlowdownSpawner Instance { get => instance; }
    public static string collectSlowdown = "CollectSlowdown_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectSlowdownSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectSlowdownSpawner allow to exist");
        }
        CollectSlowdownSpawner.instance = this;
    }
}
