using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFlySpeed : ParentMoveSpeed
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 10;
    }
}
