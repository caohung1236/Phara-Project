using UnityEditor;
#if UNITY_EDITOR
#endif
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class SceneHandler : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound;
    public GameObject settingsMenu;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(clickSound, 1);
        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
    }
}
