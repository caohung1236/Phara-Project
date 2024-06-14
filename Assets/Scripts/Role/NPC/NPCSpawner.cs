using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : Spawner
{
    private static NPCSpawner instance;
    public static NPCSpawner Instance { get => instance; }
    public static string npcOne = "NPC";

    protected override void Awake()
    {
        base.Awake();
        if (NPCSpawner.instance != null)
        {
            Debug.LogError("Only 1 NPCSpawner allow to exist");
        }
        NPCSpawner.instance = this;
    }
}
