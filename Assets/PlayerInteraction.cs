using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject currentInterObj = null;
    [SerializeField]
    public Interaction currentInterObjectScript = null;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && currentInterObj)
        {
            CheckInteraction();
        }
    }
    public void CheckInteraction()
    {
        if (currentInterObjectScript.interType == Interaction.InteractableType.Info)
        {
            currentInterObjectScript.Info();
        }
        if (currentInterObjectScript.interType == Interaction.InteractableType.Pickup)
        {
            currentInterObjectScript.Pickup();
        }
        if (currentInterObjectScript.interType == Interaction.InteractableType.Dialoge)
        {
            Debug.Log("1");
            currentInterObjectScript.Dialogue();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactible"))
        {
            //System.Console.WriteLine("Bing");
            currentInterObj = other.gameObject;
            currentInterObjectScript = currentInterObj.GetComponent<Interaction>();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Interactible"))
        {
            //System.Console.WriteLine("Bing");
            currentInterObj = null;
            currentInterObjectScript = null;
        }
    }
}
