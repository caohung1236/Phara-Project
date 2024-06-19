using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroToMain : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menu;
    public Slider slider;
    [SerializeField] Animator transitionAnim;
    public void LoadLevel(int sceneIndex)
    {
        transitionAnim.SetTrigger("End");
        StartCoroutine(LoadAsynchronously(sceneIndex));
        Time.timeScale = 1;
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        loadingScreen.SetActive(true);
        menu.SetActive(false);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            slider.value = progress;

            yield return null;
        }
    }
}
