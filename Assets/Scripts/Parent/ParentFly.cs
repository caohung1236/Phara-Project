using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : OurMonoBehaviour
{
    private static ParentFly instance;
    public static ParentFly Instance { get => instance; set => instance = value; }
    public float speed = 0;
    [SerializeField] protected Vector3 direction = Vector3.right;

    protected override void Awake()
    {
        base.Awake();
        ParentFly.instance = this;
    }

    protected virtual void Update()
    {
        transform.parent.Translate(speed * Time.deltaTime * direction);
    }
}
