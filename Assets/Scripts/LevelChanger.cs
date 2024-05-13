using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public float timeRemaining;
    [SerializeField] Animator transitionAnim;

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

        yield return new WaitForSeconds(3);
        transitionAnim.SetTrigger("End");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
