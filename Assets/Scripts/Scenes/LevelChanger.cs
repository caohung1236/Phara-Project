using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    private static LevelChanger instance;
    public static LevelChanger Instance { get { return instance; } }

    void Awake()
    {
        LevelChanger.instance = this;
    }
    
    public void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Kiểm tra xem có scene tiếp theo không
        {
            transitionAnim.SetTrigger("Start");
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
    }
}
