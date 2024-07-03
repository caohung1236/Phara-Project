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
    public int gemsCount = 0;
    public int slimesCount = 0;
    public int knightsCount = 0;
    public int goblinsCount = 0;
    public int mushroomsCount = 0;
    public int crabCount = 0;
    public int fishCount = 0;
    public int robot1Count = 0;
    public int robot2Count = 0;
    public int robot3Count = 0;
    public Text gemsText;
    public Text slimesText;
    public Text knightsText;
    public Text goblinsText;
    public Text mushroomsText;
    public Text crabText;
    public Text fishText;
    public Text robot1Text;
    public Text robot2Text;
    public Text robot3Text;
    public GameObject levelChanger;
    void Awake()
    {
        GameManager.Instance = this;
    }

    void Update()
    {
        CountGems();
        CountSlimes();
        CountKnights();
        CountGoblins();
        CountMushrooms();
        CountCrab();
        CountFish();
        CountRobot1();
        CountRobot2();
        CountRobot3();
        ConditionsMap1();
        ConditionsMap2();
        ConditionsMap3();
        ConditionsMap5();
        ClickEffect();
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

    void CountGoblins()
    {
        goblinsText.text = $":{goblinsCount}/2";
    }

    void CountMushrooms()
    {
        mushroomsText.text = $":{mushroomsCount}/2";
    }

    void CountCrab()
    {
        crabText.text = $":{crabCount}/2";
    }

    void CountFish()
    {
        fishText.text = $":{fishCount}/2";
    }

    void CountRobot1()
    {
        robot1Text.text = $":{robot1Count}/2";
    }

    void CountRobot2()
    {
        robot2Text.text = $":{robot2Count}/2";
    }

    void CountRobot3()
    {
        robot3Text.text = $":{robot3Count}/2";
    }

    void ConditionsMap1()
    {
        if (gemsCount >= 1 && slimesCount >= 1 && knightsCount >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap2()
    {
        if (gemsCount >= 2 && goblinsCount >= 2 && mushroomsCount >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap3()
    {
        if (gemsCount >= 2 && slimesCount >= 2 && crabCount >= 2 && fishCount >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap5()
    {
        if (gemsCount >= 2 && robot1Count >= 2 && robot2Count >= 2 && robot3Count >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void IsGameOver()
    {
        if (PlayerDetect.Instance.isGameOver == true)
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void Retry()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }

    private void ClickEffect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlaySFX("ClickSound");
        }
    }
}
