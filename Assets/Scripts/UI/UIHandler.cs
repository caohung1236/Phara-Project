using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Button startGame;

    public virtual void StartGame()
    {
        startGame.gameObject.SetActive(false);
    }
}
