using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance { get => instance; }

    protected virtual void Awake()
    {
        if (InputManager.instance != null)
        {
            Debug.LogError("Only 1 InputManager allow to exist");
        }
        InputManager.instance = this;
    }
}
