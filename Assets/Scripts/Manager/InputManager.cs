using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance { get => instance; }
    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }
    protected virtual void Awake()
    {
        if (InputManager.instance != null)
        {
            Debug.LogError("Only 1 InputManager allow to exist");
        }
        InputManager.instance = this;
    }

    void Update()
    {
        GetFireButtonDown();
    }

    protected virtual void GetFireButtonDown()
    {
        onFiring = Input.GetAxis("Fire2");
    }
}
