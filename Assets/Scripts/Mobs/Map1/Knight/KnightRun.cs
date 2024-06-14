using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRun : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 1.5f;
    }
}
