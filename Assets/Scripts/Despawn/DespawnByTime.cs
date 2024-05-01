using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timeLimit = 5f;
    [SerializeField] protected float timeElapsed = 0f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        timeElapsed += Time.deltaTime;
        Despawning();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void Despawning()
    {
        base.Despawning();
        if (!CanDespawn()) return;
        DespawnObject();
    }

    protected override void DespawnObject()
    {
        base.DespawnObject();
        Destroy(transform.parent.gameObject);
    }

    protected override bool CanDespawn()
    {
        if (timeElapsed > timeLimit) return true;
        return false;
    }
}
