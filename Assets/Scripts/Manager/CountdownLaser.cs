using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownLaser : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;

    void Start()
    {
        Invoke("EnabledCollider", 1.7f);
    }

    void EnabledCollider()
    {
        boxCollider2D.enabled = true;
    }
}
