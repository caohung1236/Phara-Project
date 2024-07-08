using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpawner : Spawner
{
    private static ThunderSpawner instance;

    public static ThunderSpawner Instance { get => instance; }

    public static string thunderOne = "Thunder_1";

    protected override void Awake()
    {
        base.Awake();
        if (ThunderSpawner.instance != null)
        {
            Debug.LogError("Only 1 ThunderSpawner allow to exist");
        }
        ThunderSpawner.instance = this;
    }
}
