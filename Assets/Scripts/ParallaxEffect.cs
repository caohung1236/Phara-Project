using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : OurMonoBehaviour
{
    // public Camera cam;
    // public Transform followTarget;
    // Vector2 startingPosition;
    // float startingZ;
    
    // Vector2 canMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    // float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    // float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    // float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // protected override void Start()
    // {
    //     base.Start();
    //     startingPosition = transform.position;
    //     startingZ = transform.position.z;
    // }

    // protected virtual void Update()
    // {
    //     Vector2 newPosition = startingPosition + canMoveSinceStart * parallaxFactor;

    //     transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    // }

    public float speed = 0.5f;
    public float repeatDistance = 20f;
    public Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private Vector3 startPosition;

    protected override void Start()
    {
        startPosition = transform.position;
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * speed;
        lastCameraPosition = cameraTransform.position;

        float newPosition = Mathf.Repeat(transform.position.x, repeatDistance);
        transform.position = new Vector3(startPosition.x + newPosition, transform.position.y, transform.position.z);
    }
}
