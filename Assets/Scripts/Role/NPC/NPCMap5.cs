using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMap5 : MonoBehaviour
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
    public GameObject bulletPlayerSpawn;
    public GameObject bulletRobot1Spawn;
    public GameObject bulletRobot2Spawn;
    public GameObject flyObjSpawn;
    public GameObject coBulletSpawn;
    public GameObject coShieldSpawn;
    public GameObject coExplosionSpawn;
    public GameObject coDoubleSpawn;
    public GameObject coGemsSpawn;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool isDialogueFinished = false;
    private bool isTyping = false;
    private static NPCMap5 instance;

    public static NPCMap5 Instance { get => instance; }

    void Awake()
    {
        NPCMap5.instance = this;
    }

    void Start()
    {
        gameObjects = new GameObject[] {mobGroundSpawn1, mobGroundSpawn2, bulletPlayerSpawn, bulletRobot1Spawn, bulletRobot2Spawn, flyObjSpawn, coBulletSpawn, coShieldSpawn, coExplosionSpawn, coGemsSpawn, coDoubleSpawn};
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
            PlayerMovement.Instance.jumpForce = 3;
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
            PlayerMovement.Instance.jumpForce = 0;
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
