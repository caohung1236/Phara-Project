using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesSpawner : Spawner
{
    private static WavesSpawner instance;

    public static WavesSpawner Instance { get => instance; }

    public static string wavesOne = "Waves_1";

    protected override void Awake()
    {
        base.Awake();
        if (WavesSpawner.instance != null)
        {
            Debug.LogError("Only 1 WavesSpawner allow to exist");
        }
        WavesSpawner.instance = this;
    }
}
