using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBulletSpawner : Spawner
{
    private static CollectBulletSpawner instance;
    public static CollectBulletSpawner Instance { get => instance; }
    public static string collectBullet = "CollectBullet_1";

    protected override void Awake()
    {
        base.Awake();
        if (CollectBulletSpawner.instance != null)
        {
            Debug.Log("Only 1 CollectibleSpawner allow to exist");
        }
        CollectBulletSpawner.instance = this;
    }
}
