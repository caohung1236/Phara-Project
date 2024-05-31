using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToMain : MonoBehaviour
{
    public string loadScene;
    public void NextLevel()
    {
        SceneManager.LoadScene(loadScene);
    }
}
