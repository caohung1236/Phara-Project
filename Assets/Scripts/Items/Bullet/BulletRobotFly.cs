using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRobotFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        speed = 20;
    }
}
