using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : Spawner
{
    private static TreeSpawner instance;

    public static TreeSpawner Instance { get => instance; }

    public static string treeOne = "Tree_1";

    protected override void Awake()
    {
        base.Awake();
        if (TreeSpawner.instance != null)
        {
            Debug.LogError("Only 1 TreeSpawner allow to exist");
        }
        TreeSpawner.instance = this;
    }
}
