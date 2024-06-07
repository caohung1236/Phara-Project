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
    public Text gemsText;


    // public Text enemysCount;
    void Awake()
    {
        GameManager.Instance = this;
    }

    void Update()
    {
        CountGems();
        IsGameOver();
    }

    void CountGems()
    {
        gemsText.text = $":{gemsCount}/5";
        if (gemsCount < 5)
        {
            gemsText.text = $":{gemsCount}/5";
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

    public void Retry()
    {
        PausePanelOutro();
        gameOverMenu.SetActive(false);
    }
    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        gameOverPanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }

    void PausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        gameOverPanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);
    }
}
