using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
   public enum InteractableType
    {
        Nothing,
        Info,
        Pickup,
        Dialoge
    }

    [Header("interactible type")]
    public InteractableType interType;

    [Header("Info message")]
    public string infoMessage;
    public TMP_Text infoText;

    [TextArea]
    public string[] sentences;
    private int currentsentence;

    void start()
    {
        infoText = GameObject.Find("Info").GetComponent<TMP_Text>();
    }

    public void Pickup()
    {
        this.gameObject.SetActive(false);
    }

    public void Info()
    {
        infoText.text = infoMessage;
        ShowInfo(infoMessage, 3.0f);
    }

    public void Dialogue()
    {
        GameObject.FindObjectOfType<DialogManager>().StartDialogue(sentences);
    }

    public IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}
