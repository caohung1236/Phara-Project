using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFlySpeed : ParentMoveSpeed
{
    public float speedIncreaseRate = 15f;

    protected override void Start()
    {
        base.Start();
        speed = 10;
    }
    protected override void Update()
    {
        base.Update();
        speed += speedIncreaseRate * Time.deltaTime;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 10;
    }
}
