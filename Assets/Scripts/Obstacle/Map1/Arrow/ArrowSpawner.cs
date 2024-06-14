using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : Spawner
{
    private static ArrowSpawner instance;
    public static ArrowSpawner Instance { get => instance; }
    public static string arrowOne = "Arrow_1";

    protected override void Awake()
    {
        base.Awake();
        if (ArrowSpawner.instance != null)
        {
            Debug.Log("Only 1 ArrowSpawner allow to exist");
        }
        ArrowSpawner.instance = this;
    }
}
