using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCRandom : OurMonoBehaviour
{
    [SerializeField] protected bool isSpawning = false;
    protected float rangeX = 15f;
    protected float rangeY = 1f;
    [SerializeField] protected float spawnDelay = 5f; // Thời gian đếm ngược trước khi spawn
    protected float spawnTimer;

    protected override void Start()
    {
        base.Start();
        spawnTimer = spawnDelay; // Khởi tạo bộ đếm ngược
    }

    protected virtual void Update()
    {
        if (!isSpawning)
        {
            spawnTimer -= Time.deltaTime; // Giảm thời gian đếm ngược
            if (spawnTimer <= 0)
            {
                SpawnNPC();
                spawnTimer = spawnDelay; // Đặt lại bộ đếm ngược
            }
        }
    }

    protected virtual void SpawnNPC()
    {
        float spawnPosY= UnityEngine.Random.Range(-rangeY, rangeY + 5);
        Vector3 spawnPos = new(0, spawnPosY, 0);
        Quaternion rotation = transform.rotation;
        Transform newNPC = NPCSpawner.Instance.Spawn(NPCSpawner.npcOne, spawnPos, rotation);
        if (newNPC == null) return;
        newNPC.gameObject.SetActive(true);
        isSpawning = true;
        Debug.Log("Spawning...");
    }

    protected void ResetSpawning()
    {
        isSpawning = false;
    }
}
