using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveSpeed : ParentMoveSpeed
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 10;
    }
}
