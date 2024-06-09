using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; set => instance = value; }
    public GameObject gameOverMenu;
    [SerializeField] RectTransform gameOverPanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup;
    public int gemsCount = 0;
    public int slimesCount = 0;
    public int knightsCount = 0;
    public Text gemsText;
    public Text slimesText;
    public Text knightsText;


    // public Text enemysCount;
    void Awake()
    {
        GameManager.Instance = this;
    }

    void Update()
    {
        CountGems();
        CountSlimes();
        CountKnights();
        ConditionsMap1();
        IsGameOver();
    }

    void CountGems()
    {
        gemsText.text = $":{gemsCount}/1";
    }

    void CountSlimes()
    {
        slimesText.text = $":{slimesCount}/1";
    }

    void CountKnights()
    {
        knightsText.text = $":{knightsCount}/2";
    }

    void ConditionsMap1()
    {
        if (gemsCount == 1 && slimesCount == 1 && knightsCount == 2)
        {
            // SceneManager.LoadScene(2);
        }
    }

    void IsGameOver()
    {
        if (PlayerDetect.Instance.isGameOver == true)
        {
            PausePanelIntro();
            gameOverMenu.SetActive(true);
        }
    }

    public async void Retry()
    {
        await PausePanelOutro();
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        gameOverPanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }

    async Task PausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        await gameOverPanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}
