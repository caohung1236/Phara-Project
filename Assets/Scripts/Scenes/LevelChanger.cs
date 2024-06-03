using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public float timeRemaining;
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
        float timer = timeRemaining;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer -= 1f;
        }

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Kiểm tra xem có scene tiếp theo không
        {
            transitionAnim.SetTrigger("End");
            SceneManager.LoadSceneAsync(nextSceneIndex);
            transitionAnim.SetTrigger("Start");
        }
    }
}
