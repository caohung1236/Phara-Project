using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixSpawner: Spawner
{
    private static PhoenixSpawner instance;
    public static PhoenixSpawner Instance { get => instance; }
    public static string phoenixOne = "Phoenix_1";

    protected override void Awake()
    {
        base.Awake();
        if (PhoenixSpawner.instance != null)
        {
            Debug.Log("Only 1 PhoenixSpawner allow to exist");
        }
        PhoenixSpawner.instance = this;
    }
}
