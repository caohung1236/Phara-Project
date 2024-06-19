using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectExplosionSpawner : Spawner
{
    private static CollectExplosionSpawner instance;
    public static CollectExplosionSpawner Instance { get => instance; }
    public static string collectExplosion = "CollectExplosion_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectExplosionSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectExplosionSpawner allow to exist");
        }
        CollectExplosionSpawner.instance = this;
    }
}
