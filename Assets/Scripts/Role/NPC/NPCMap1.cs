using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCMap1 : MonoBehaviour
{
    private GameObject[] gameObjects;
    public GameObject dialoguePanel;
    public GameObject contButton;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject background4;
    public GameObject sceneTransition;
    public Text dialogueText;
    [SerializeField] Animator transitionAnim;
    public GameObject mobGroundSpawn1;
    public GameObject mobGroundSpawn2;
    public GameObject bulletSpawn;
    public GameObject flyObjSpawn;
    public GameObject coBulletSpawn;
    public GameObject coGemsSpawn;
    public Text tutorialText1;
    public Text tutorialText2;
    public GameObject playerMovement;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public float displayDuration = 10f;
    public float elapsedTime = 0f;
    public bool playerIsClose;
    private bool isDialogueFinished = false;
    private bool isTyping = false;
    private static NPCMap1 instance;

    public static NPCMap1 Instance { get => instance; }

    void Awake()
    {
        NPCMap1.instance = this;
    }

    void Start()
    {
        gameObjects = new GameObject[] {mobGroundSpawn1, mobGroundSpawn2, bulletSpawn, flyObjSpawn, coBulletSpawn, coGemsSpawn, playerMovement};
        Invoke(nameof(HideText), displayDuration);
        tutorialText1.enabled = true;
        tutorialText2.enabled = false;
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
            playerMovement.SetActive(true);
            tutorialText2.enabled = true;
            background1.SetActive(true);
            background2.SetActive(true);
            background3.SetActive(false);
            background4.SetActive(false);
            gameObject.SetActive(false);
            ActivateGameObjects();
            transitionAnim.SetTrigger("End");
        }

        if (tutorialText2.enabled)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= displayDuration)
            {
                tutorialText2.enabled = false;
            }
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

    public void SkipDialogue()
    {
        if (isTyping == true)
        {
            StopCoroutine(Typing());
            dialogueText.text = dialogue[index];
            isTyping = false;
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
            background1.SetActive(false);
            background2.SetActive(false);
            background3.SetActive(true);
            background4.SetActive(true);
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

    private void HideText()
    {
        tutorialText1.enabled = false;
    }
}
