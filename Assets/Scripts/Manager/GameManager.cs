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
    public int gemsCount2 = 0;
    public int gemsCount3 = 0;
    public int gemsCount5 = 0;
    public float gemsCount6 = 0;
    public int gemsCount7 = 0;
    public int slimesCount = 0;
    public int slimesCount3 = 0;
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
    public int hellHorseCount = 0;
    public int hellDogCount = 0;
    public int groundDragonCount = 0;
    public int monsterFlyCount = 0;
    public int demonFlyCount = 0;
    public Text gemsText;
    public Text gemsText2;
    public Text gemsText3;
    public Text gemsText5;
    public Text gemsText6;
    public Text gemsText7;
    public Text slimesText;
    public Text slimesText3;
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
        CountGems2();
        CountGems3();
        CountGems5();
        CountGems6();
        CountGems7();

        CountSlimes();
        CountKnights();

        CountGoblins();
        CountMushrooms();
        CountBats();

        CountCrab();
        CountFish();
        CountFly();
        CountSlimes3();

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
        // ConditionsEnd();

        ClickEffect();

        IsGameOver();
    }

    void CountGems()
    {
        gemsText.text = $":{gemsCount}/3";
    }

    void CountGems2()
    {
        gemsText2.text = $":{gemsCount2}/5";
    }

    void CountGems3()
    {
        gemsText3.text = $":{gemsCount3}/10";
    }

    void CountGems5()
    {
        gemsText5.text = $":{gemsCount5}/20";
    }

    void CountGems6()
    {
        gemsText6.text = $":{gemsCount6}/30";
    }

    void CountGems7()
    {
        gemsText7.text = $":{gemsCount7}/60";
    }

    void CountSlimes()
    {
        slimesText.text = $":{slimesCount}/3";
    }

    void CountKnights()
    {
        knightsText.text = $":{knightsCount}/5";
    }

    void CountGoblins()
    {
        goblinsText.text = $":{goblinsCount}/3";
    }

    void CountMushrooms()
    {
        mushroomsText.text = $":{mushroomsCount}/5";
    }

    void CountBats()
    {
        batsText.text = $":{batsCount}/2";
    }

    void CountCrab()
    {
        crabText.text = $":{crabCount}/10";
    }

    void CountFish()
    {
        fishText.text = $":{fishCount}/13";
    }

    void CountFly()
    {
        flyText.text = $":{flyCount}/5";
    }

    void CountSlimes3()
    {
        slimesText3.text = $":{slimesCount3}/15";
    }

    void CountRobot1()
    {
        robot1Text.text = $":{robot1Count}/15";
    }

    void CountRobot2()
    {
        robot2Text.text = $":{robot2Count}/17";
    }

    void CountRobot3()
    {
        robot3Text.text = $":{robot3Count}/7";
    }

    void CountBirds()
    {
        birdsText.text = $":{birdsCount}/20";
    }

    void CountDragons()
    {
        dragonsText.text = $":{dragonsCount}/15";
    }

    void CountBatMonsters()
    {
        batMonstersText.text = $":{batMonstersCount}/15";
    }

    void CountPhoenix()
    {
        phoenixText.text = $":{phoenixCount}/10";
    }

    void CountHellHorse()
    {
        hellHorseText.text = $":{hellHorseCount}/20";
    }

    void CountHellDog()
    {
        hellDogText.text = $":{hellDogCount}/25";
    }

    void CountGroundDragon()
    {
        groundDragonText.text = $":{groundDragonCount}/15";
    }

    void CountMonsterFly()
    {
        monsterFlyText.text = $":{monsterFlyCount}/25";
    }

    void CountDemonFly()
    {
        demonFlyText.text = $":{demonFlyCount}/25";
    }

    void ConditionsMap1()
    {
        if (gemsCount >= 3 && slimesCount >= 3 && knightsCount >= 5)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap2()
    {
        if (gemsCount2 >= 5 && goblinsCount >= 5 && mushroomsCount >= 3 && batsCount >= 2)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap3()
    {
        if (gemsCount3 >= 10 && slimesCount3 >= 15 && crabCount >= 10 && fishCount >= 15 && flyCount >= 5)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap5()
    {
        if (gemsCount5 >= 20 && robot1Count >= 15 && robot2Count >= 17 && robot3Count >= 7)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap6()
    {
        if (gemsCount6 >= 30 && birdsCount >= 20 && dragonsCount >= 15 && batMonstersCount >= 15 && phoenixCount >= 10)
        {
            levelChanger.SetActive(true);
        }
    }

    void ConditionsMap7()
    {
        if (gemsCount7 >= 60 && hellHorseCount >= 20 && hellDogCount >= 25 && groundDragonCount >= 15 && dragonsCount >= 15 && monsterFlyCount >= 25 && demonFlyCount >= 25)
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
