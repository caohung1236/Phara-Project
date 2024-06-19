using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGemSpawner : Spawner
{
    private static CollectGemSpawner instance;
    public static CollectGemSpawner Instance { get => instance; }
    public static string gemOne = "Gem_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectGemSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectGemSpawner allow to exist");
        }
        CollectGemSpawner.instance = this;
    }
}
