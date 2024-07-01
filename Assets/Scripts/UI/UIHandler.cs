using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public string scene;

    public virtual void Skip()
    {
        SceneManager.LoadScene(scene);
    }
}
