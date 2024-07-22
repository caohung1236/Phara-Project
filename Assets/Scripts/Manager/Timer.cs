using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    public GameObject levelChanger;
    private bool isRunning = true;
    private static Timer instance;
    public static Timer Instance { get => instance; set => instance = value; }
    float elapsedTime;

    void Awake()
    {
        Timer.instance = this;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}/02:30", minutes, seconds);
            if (minutes >= 2f && seconds >= 30f)
            {
                levelChanger.SetActive(true);
            }
        }
        
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
