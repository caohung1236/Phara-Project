using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDoubleSpawner : Spawner
{
    private static CollectDoubleSpawner instance;
    public static CollectDoubleSpawner Instance { get => instance; }
    public static string collectDouble = "CollectDouble_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectDoubleSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectDoubleSpawner allow to exist");
        }
        CollectDoubleSpawner.instance = this;
    }
}
