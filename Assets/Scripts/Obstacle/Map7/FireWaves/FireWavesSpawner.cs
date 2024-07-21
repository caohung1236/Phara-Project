using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWavesSpawner : Spawner
{
    private static FireWavesSpawner instance;

    public static FireWavesSpawner Instance { get => instance; }

    public static string fireWavesOne = "FireWaves_1";

    protected override void Awake()
    {
        base.Awake();
        if (FireWavesSpawner.instance != null)
        {
            Debug.LogError("Only 1 FireWavesSpawner allow to exist");
        }
        FireWavesSpawner.instance = this;
    }
}
