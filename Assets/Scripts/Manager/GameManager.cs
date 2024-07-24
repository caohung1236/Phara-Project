using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public int batsCount = 0;
    public int crabCount = 0;
    public int fishCount = 0;
    public int flyCount = 0;
    public int robot1Count = 0;
    public int robot2Count = 0;
    public int robot3Count = 0;
    public int birdsCount = 0;
    public int dragonsCount = 0;
    public int batMonstersCount = 0;
    public int phoenixCount = 0;
    public float hellHorseCount = 0;
    public int hellDogCount = 0;
    public int groundDragonCount = 0;
    public int monsterFlyCount = 0;
    public int demonFlyCount = 0;
    public Text gemsText;
    public Text slimesText;
    public Text knightsText;
    public Text goblinsText;
    public Text mushroomsText;
    public Text batsText;
    public Text crabText;
    public Text fishText;
    public Text flyText;
    public Text robot1Text;
    public Text robot2Text;
    public Text robot3Text;
    public Text birdsText;
    public Text dragonsText;
    public Text batMonstersText;
    public Text phoenixText;
    public Text hellHorseText;
    public Text hellDogText;
    public Text groundDragonText;
    public Text monsterFlyText;
    public Text demonFlyText;
    public GameObject levelChanger;
    void Awake()
    {
        GameManager.instance = this;
    }

    void Update()
    {
        CountGems();

        CountSlimes();
        CountKnights();

        CountGoblins();
        CountMushrooms();
        CountBats();

        CountCrab();
        CountFish();
        CountFly();

        CountRobot1();
        CountRobot2();
        CountRobot3();

        CountBirds();
        CountDragons();
        CountDragons();
        CountBatMonsters();
        CountPhoenix();

        CountHellHorse();
        CountHellDog();
        CountGroundDragon();
        CountMonsterFly();
        CountDemonFly();

        ConditionsMap1();
        ConditionsMap2();
        ConditionsMap3();
        ConditionsMap5();
        ConditionsMap6();
        ConditionsMap7();

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

    void CountBats()
    {
        batsText.text = $":{batsCount}/2";
    }

    void CountCrab()
    {
        crabText.text = $":{crabCount}/2";
    }

    void CountFish()
    {
        fishText.text = $":{fishCount}/2";
    }


    void CountFly()
    {
        flyText.text = $":{flyCount}/2";
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

    void CountBirds()
    {
        birdsText.text = $":{birdsCount}/2";
    }

    void CountDragons()
    {
        dragonsText.text = $":{dragonsCount}/2";
    }

    void CountBatMonsters()
    {
        batMonstersText.text = $":{batMonstersCount}/2";
    }

    void CountPhoenix()
    {
        phoenixText.text = $":{phoenixCount}/2";
    }

    void CountHellHorse()
    {
        hellHorseText.text = $":{hellHorseCount}/2";
    }

    void CountHellDog()
    {
        hellDogText.text = $":{hellDogCount}/2";
    }

    void CountGroundDragon()
    {
        groundDragonText.text = $":{groundDragonCount}/2";
    }

    void CountMonsterFly()
    {
        monsterFlyText.text = $":{monsterFlyCount}/2";
    }

    void CountDemonFly()
    {
        demonFlyText.text = $":{demonFlyCount}/2";
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
        if (gemsCount >= 2 && goblinsCount >= 2 && mushroomsCount >= 2 && batsCount >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap3()
    {
        if (gemsCount >= 2 && slimesCount >= 2 && crabCount >= 2 && fishCount >= 2 && flyCount >= 2)
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

    void ConditionsMap6()
    {
        if (gemsCount >= 2 && birdsCount >= 2 && dragonsCount >= 2 && batMonstersCount >= 2 && phoenixCount >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap7()
    {
        if (gemsCount >= 2 && hellHorseCount >= 2 && hellDogCount >= 2 && groundDragonCount >= 2 && dragonsCount >= 2 && monsterFlyCount >= 2 && demonFlyCount >= 2)
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
        SceneManager.LoadScene(3);
    }

    private void ClickEffect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlaySFX("ClickSound");
        }
    }
}
