using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : Spawner
{
    private static SlimeSpawner instance;

    public static SlimeSpawner Instance { get => instance; }

    public static string slimeOne = "Slime_1";

    protected override void Awake()
    {
        base.Awake();
        if (SlimeSpawner.instance != null)
        {
            Debug.LogError("Only 1 SlimeSpawner allow to exist");
        }
        SlimeSpawner.instance = this;
    }
}
