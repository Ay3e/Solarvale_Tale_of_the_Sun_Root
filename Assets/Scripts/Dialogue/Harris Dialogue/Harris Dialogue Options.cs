using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarrisDialogueOptions : MonoBehaviour
{
    [SerializeField] private GameObject dialogueOptions0;
    [SerializeField] private GameObject dialogueOptions1;
    public void DialogueOptionButton0()
    {
        SickGuyDialogue.dialogueOptionChosen = true;
        //Disable all buttons
        dialogueOptions0.SetActive(false);
        dialogueOptions1.SetActive(false);
        //Check if any flowers are in inventory

        //If they do display inventory
        InventoryManager.turnInventoryOn = true;
    }

    public void DialogueOptionButton1()
    {
        //Disable buttons
        dialogueOptions0.SetActive(false);
        dialogueOptions1.SetActive(false);
        //Exit dialogue
        SickGuyDialogue.dialogueOptionChosen = false;
        SickGuyDialogue.isInDialogueOptions = false;
        SickGuyDialogue.currentDialogueIndex++;
    }

    public void DialogueOptionButton2()
    {
        SickGuyDialogue.dialogueOptionChosen = true;
        //Disable all buttons
        dialogueOptions0.SetActive(false);
        dialogueOptions1.SetActive(false);
        //Check if any flowers are in inventory

        //If they do display inventory
        InventoryManager.turnInventoryOn = true;
    }
}
