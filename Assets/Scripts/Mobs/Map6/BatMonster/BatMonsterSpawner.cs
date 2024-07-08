using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMonsterSpawner : Spawner
{
    private static BatMonsterSpawner instance;
    public static BatMonsterSpawner Instance { get => instance; }
    public static string batOne = "BatMonster_1";

    protected override void Awake()
    {
        base.Awake();
        if (BatMonsterSpawner.instance != null)
        {
            Debug.Log("Only 1 BatMonsterSpawner allow to exist");
        }
        BatMonsterSpawner.instance = this;
    }
}
