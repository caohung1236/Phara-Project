using UnityEditor;
#if UNITY_EDITOR
#endif
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
