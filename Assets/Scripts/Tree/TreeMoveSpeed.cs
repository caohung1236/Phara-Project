using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMoveSpeed : ParentMoveSpeed
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 1f;
    }
}
