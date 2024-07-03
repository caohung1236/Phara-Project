using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : Spawner
{
    private static BirdSpawner instance;
    public static BirdSpawner Instance { get => instance; }
    public static string birdOne = "Bird_1";

    protected override void Awake()
    {
        base.Awake();
        if (BirdSpawner.instance != null)
        {
            Debug.Log("Only 1 BirdSpawner allow to exist");
        }
        BirdSpawner.instance = this;
    }
}
