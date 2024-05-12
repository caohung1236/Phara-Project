using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Transform mainCam;
    protected override void FixedUpdate()
    {
        Despawning();
    }

    protected override void LoadComponents()
    {
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    protected override void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }

    protected override void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(transform.position, mainCam.position);
        if (distance > disLimit) return true;
        return false;
    }
}
