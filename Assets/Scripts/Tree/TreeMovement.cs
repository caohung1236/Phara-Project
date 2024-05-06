using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 15f;
    protected float rangeY = 1.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            SpawnTree();
        }
    }

    protected virtual void SpawnTree()
    {
        Vector3 spawnPos = new(rangeX, -rangeY, 0);
        Quaternion rotation = transform.rotation;
        Transform newTree = TreeSpawner.Instance.Spawn(TreeSpawner.treeOne, spawnPos, rotation);
        if (newTree == null) return;
        newTree.gameObject.SetActive(true);
        isSpawning = true;
        Invoke(nameof(ResetSpawning), 10f);
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
