using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : OurMonoBehaviour
{
    private static NPCMove instance;
    public static NPCMove Instance { get => instance; }

    public float speed;
    [SerializeField] protected Vector3 direction = Vector3.right;
    protected override void Awake()
    {
        base.Awake();
        NPCMove.instance = this;
    }

    protected virtual void Update()
    {
        transform.parent.Translate(speed * Time.deltaTime * direction);
    }
}
