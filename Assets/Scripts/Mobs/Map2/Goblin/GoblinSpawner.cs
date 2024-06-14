using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : Spawner
{
    private static GoblinSpawner instance;

    public static GoblinSpawner Instance { get => instance; }

    public static string goblinOne = "Goblin_1";

    protected override void Awake()
    {
        base.Awake();
        if (GoblinSpawner.instance != null)
        {
            Debug.LogError("Only 1 GoblinSpawner allow to exist");
        }
        GoblinSpawner.instance = this;
    }
}
