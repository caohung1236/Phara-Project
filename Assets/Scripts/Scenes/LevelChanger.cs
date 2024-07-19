using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public int nextSceneIndex;
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
        yield return new WaitForSeconds(1f);
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Kiểm tra xem có scene tiếp theo không
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
    }
}
