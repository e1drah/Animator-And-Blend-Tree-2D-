using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    public GameObject player;
    public Animator animator;

    private Queue<string> dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);
        
        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }
        SuspendPlayerControl();
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentLine = dialogue.Dequeue();
        dialogueText.text = currentLine;
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogue.Clear();

        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;

    }
    void SuspendPlayerControl()
    {
        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;

        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
