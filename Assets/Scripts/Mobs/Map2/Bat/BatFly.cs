using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 10;
    }
}
