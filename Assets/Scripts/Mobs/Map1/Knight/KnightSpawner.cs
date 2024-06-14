using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : Spawner
{
    private static KnightSpawner instance;

    public static KnightSpawner Instance { get => instance; }

    public static string knightOne = "Knight_1";

    protected override void Awake()
    {
        base.Awake();
        if (KnightSpawner.instance != null)
        {
            Debug.LogError("Only 1 KnightSpawner allow to exist");
        }
        KnightSpawner.instance = this;
    }
}
