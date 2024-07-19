using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMoveSpeed : OurMonoBehaviour
{
    private static ParentMoveSpeed instance;
    public static ParentMoveSpeed Instance { get => instance; }
    public float speed;
    [SerializeField] protected Vector3 direction = Vector3.right;

    protected override void Awake()
    {
        ParentMoveSpeed.instance = this;
    }

    protected virtual void Update()
    {
        transform.parent.Translate(speed * Time.deltaTime * direction);
    }
}
