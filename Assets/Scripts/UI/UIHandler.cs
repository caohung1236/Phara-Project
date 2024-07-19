using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public string scene;
    public Animator animator;
    public GameObject animationObject;

    public virtual void Skip()
    {
        animationObject.SetActive(true);
        animator.Play("Base Layer.Transition Fade", 0, 1.5f);
        SceneManager.LoadScene(scene);
    }
}
