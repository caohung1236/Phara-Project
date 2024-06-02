using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject dialoguePanel;
    public GameObject contButton;
    public GameObject background;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject sceneTransition;
    public Text dialogueText;
    [SerializeField] Animator transitionAnim;
    public GameObject slimeSpawn;
    public GameObject knightSpawn;
    public GameObject bulletSpawn;
    public GameObject arrowSpawn;
    public GameObject coBulletSpawn;
    public GameObject coShieldSpawn;
    public GameObject coGemsSpawn;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    private bool isDialogueFinished = false;
    private bool isTyping = false;

    void Start()
    {
        gameObjects = new GameObject[] {slimeSpawn, knightSpawn, bulletSpawn, arrowSpawn, coBulletSpawn, coShieldSpawn, coGemsSpawn};
    }

    void Update()
    {
        if (playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy && !isDialogueFinished)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        else if (dialoguePanel.activeInHierarchy)
        {
            ZeroText();
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

        if (isDialogueFinished == true)
        {
            transitionAnim.SetTrigger("Start");
            NPCMove.Instance.speed = 3;
            PlayerMovement.Instance.jumpForce = 3;
            background.SetActive(false);
            background1.SetActive(false);
            background2.SetActive(true);
            background3.SetActive(true);
            gameObject.SetActive(false);
            ActivateGameObjects();
            transitionAnim.SetTrigger("End");
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        isTyping = true;
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        if (isTyping)
        {
            return;
        }
        
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            dialoguePanel.SetActive(false);
            isDialogueFinished = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneTransition.SetActive(true);
            transitionAnim.SetTrigger("Start");
            playerIsClose = true;
            isDialogueFinished = false;
            NPCMove.Instance.speed = 0;
            PlayerMovement.Instance.jumpForce = 0;
            background.SetActive(true);
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
            transitionAnim.SetTrigger("End");
        }
    }

    void ActivateGameObjects()
    {
        foreach(GameObject go in gameObjects)
        {
            go.SetActive(true);
        }
    }
}
