using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMap7 : MonoBehaviour
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
    public GameObject mobGroundSpawn3;
    public GameObject flySpawn1;
    public GameObject flySpawn2;
    public GameObject flySpawn3;
    public GameObject bulletPlayerSpawn;
    public GameObject coBulletSpawn;
    public GameObject coShieldSpawn;
    public GameObject coExplosionSpawn;
    public GameObject coDoubleSpawn;
    public GameObject coGemsSpawn;
    public GameObject obstacles1;
    public GameObject obstacles2;
    public GameObject playerMovement;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool isDialogueFinished = false;
    private bool isTyping = false;
    private static NPCMap7 instance;

    public static NPCMap7 Instance { get => instance; }

    void Awake()
    {
        NPCMap7.instance = this;
    }

    void Start()
    {
        gameObjects = new GameObject[] {mobGroundSpawn1, mobGroundSpawn2, mobGroundSpawn3, flySpawn1, flySpawn2, flySpawn2, bulletPlayerSpawn, coBulletSpawn, coShieldSpawn, coExplosionSpawn, coDoubleSpawn, coGemsSpawn, obstacles1, obstacles2, playerMovement};
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
            background1.SetActive(true);
            background2.SetActive(true);
            background3.SetActive(false);
            background4.SetActive(false);
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
}