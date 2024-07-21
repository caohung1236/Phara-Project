using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlySpawner : Spawner
{
    private static MonsterFlySpawner instance;

    public static MonsterFlySpawner Instance { get => instance; }

    public static string monsterFlyOne = "MonsterFly_1";

    protected override void Awake()
    {
        base.Awake();
        if (MonsterFlySpawner.instance != null)
        {
            Debug.LogError("Only 1 MonsterFlySpawner allow to exist");
        }
        MonsterFlySpawner.instance = this;
    }
}
