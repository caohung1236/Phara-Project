using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pillar;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    void Start()
    {
        SpawnPillar();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPillar();
            timer = 0;
        }
    }

    void SpawnPillar()
    {
        float lowestPoint = -1;
        float hightestPoint = 2;
        
        Instantiate(pillar, new Vector3(transform.position.x, Random.Range(lowestPoint, hightestPoint), 0), transform.rotation);
    }
}
