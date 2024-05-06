using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : OurMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 direction = Vector3.right;

    protected virtual void Update()
    {
        transform.parent.Translate(speed * Time.deltaTime * direction);
    }
}
