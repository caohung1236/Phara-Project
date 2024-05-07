using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : Spawner
{
    private static GroundSpawner instance;
    public static GroundSpawner Instance { get => instance; }
    public static string groundOne = "Ground_1";

    protected override void Awake()
    {
        base.Awake();
        if (GroundSpawner.instance != null)
        {
            Debug.Log("Only 1 GroundSpawner allow to exist");
        }
        GroundSpawner.instance = this;
    }
}
