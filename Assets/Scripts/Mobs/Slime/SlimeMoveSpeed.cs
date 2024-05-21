using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveSpeed : ParentMoveSpeed
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 1.5f;
    }
}
