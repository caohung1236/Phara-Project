using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : OurMonoBehaviour
{
    [SerializeField] protected float speed = 0.5f;
    [SerializeField] protected float repeatDistance = 21;
    private Vector3 startPosition;
    protected override void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, repeatDistance);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
