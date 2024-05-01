using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
    }
    protected virtual void Start()
    {

    }

    protected virtual void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void LoadComponents()
    {

    }

    protected virtual void ResetValue()
    {

    }
}
