using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneData : OurMonoBehaviour
{
    private static SceneData instance;

    public static SceneData Instance { get => instance; set => instance = value; }
    public bool isSceneSaved;

    protected override void Awake()
    {
        base.Awake();
        SceneData.instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("CurrentScene", currentSceneIndex);
            isSceneSaved = true;
            Debug.Log("Saved");
        }
    }
    
    public void OnContinueButton()
    {
        int savedSceneIndex = PlayerPrefs.GetInt("CurrentScene", 0);
        SceneManager.LoadScene(savedSceneIndex);
        Time.timeScale = 1;
    }
}
