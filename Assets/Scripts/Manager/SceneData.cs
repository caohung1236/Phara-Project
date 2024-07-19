using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneData : OurMonoBehaviour
{
    private static SceneData instance;

    public static SceneData Instance { get => instance; set => instance = value; }

    protected override void Awake()
    {
        base.Awake();
        SceneData.instance = this;
    }
    public void SaveScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("CurrentScene", currentSceneIndex);
    }

    public void OnContinueButton()
    {
        int savedSceneIndex = PlayerPrefs.GetInt("CurrentScene", 0);
        SceneManager.LoadScene(savedSceneIndex);
        Time.timeScale = 1;
    }
}
