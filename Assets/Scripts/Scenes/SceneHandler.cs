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
    public GameObject creditMenu;
    [SerializeField] RectTransform optionsPanelRect;
    [SerializeField] RectTransform creditPanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] CanvasGroup canvasGroup2;

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
        SceneData.Instance.isSceneSaved = false;
#else
    Application.Quit();
#endif
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        OptionsPanelIntro();
    }

    public void Back()
    {
        OptionsPanelOutro();
        settingsMenu.SetActive(false);
        creditMenu.SetActive(false);
    }

    public void Credit()
    {
        creditMenu.SetActive(true);
        OptionsPanelIntro();
    }

    void OptionsPanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        canvasGroup2.DOFade(1, tweenDuration).SetUpdate(true);
        optionsPanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
        creditPanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }

    void OptionsPanelOutro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        canvasGroup2.DOFade(1, tweenDuration).SetUpdate(true);
        optionsPanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);
        creditPanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);
    }
}
