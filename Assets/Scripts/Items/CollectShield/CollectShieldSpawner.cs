using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShieldSpawner : Spawner
{
    private static CollectShieldSpawner instance;
    public static CollectShieldSpawner Instance { get => instance; }
    public static string collectShield = "CollectShield_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectShieldSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectibleSpawner allow to exist");
        }
        CollectShieldSpawner.instance = this;
    }
}
