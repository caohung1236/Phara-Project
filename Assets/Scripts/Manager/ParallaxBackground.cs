using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public RectTransform[] backgroundLayers;
    public float[] scrollSpeed;
    public float repeatDistance = 21;

    private Vector2[] startPosition;

    void Start()
    {
        startPosition = new Vector2[backgroundLayers.Length];
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            startPosition[i] = backgroundLayers[i].anchoredPosition;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            float newPositionX = Mathf.Repeat(Time.time * scrollSpeed[i], repeatDistance);
            Vector2 newPosition = startPosition[i] + Vector2.left * newPositionX;

            backgroundLayers[i].anchoredPosition = newPosition;
        }
    }
}
