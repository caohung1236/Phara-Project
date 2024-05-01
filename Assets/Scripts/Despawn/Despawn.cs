using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : OurMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();
}
