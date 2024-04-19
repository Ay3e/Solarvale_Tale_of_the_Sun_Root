using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class SickGuyDialogue : MonoBehaviour
{
    [SerializeField] private GameObject canvasInteractiveUserInterfacePopUp;
    [SerializeField] private string nameOfInteract;
    [SerializeField] private TextMeshProUGUI nameOfInteractTMP;

    [Header("Dialogue Functions")]
    [SerializeField] private GameObject dialogueParent;
    [TextArea][SerializeField] private string[] dialogueInput;
    [TextArea][SerializeField] private string[] dialogueName;
    [SerializeField] private TextMeshProUGUI dialogueTMP;
    [SerializeField] private TextMeshProUGUI dialogueNPCNameTMP;
    public static int currentDialogueIndex = 0;

    [Header("Hide UI")]
    [SerializeField] private GameObject[] hideUI;

    [Header("Cinemachine")]
    [SerializeField] private CinemachineBrain cinemachineBrain;

    [Header("Dialogue Options")]
    [SerializeField] private bool isThereDialogueOptions;
    [SerializeField] private int atWhatPointIsTheDialogueOptioninDialogue;
    [SerializeField] private int howManyDialogueOptions;
    [SerializeField] private GameObject dialogueOptionParent; 
    [SerializeField] private GameObject[] dialogueOptionsGameObjects;
    [SerializeField] private TextMeshProUGUI[] dialogueOptionText;
    [TextArea][SerializeField] private string[] whatAreTheDialogueOptionsText;
    public static bool isInDialogueOptions = false;
    public static bool dialogueOptionChosen = false;


    private void Start()
    {
        dialogueParent.SetActive(false);
        dialogueOptionParent.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentDialogueIndex);
        if (!ThirdPersonMovement.isInDialogue)
        {
            canvasInteractiveUserInterfacePopUp.SetActive(true);
        }
        nameOfInteractTMP.text = nameOfInteract;

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Set mouse to be visible
            CursorManager.setCursor = true;

            //Disenable cinemachine to stop camera movement
            cinemachineBrain.enabled = false;

            //Tells the script that player is interacting with a character
            ThirdPersonMovement.isInDialogue = true;

            dialogueParent.SetActive(true);

            //Hide all UI elements while in dialogue
            for(int i = 0; i< hideUI.Length; i++)
            {
                hideUI[i].SetActive(false);
            }
        }

        //If player is in a dialogue scene then check for the following
        if (ThirdPersonMovement.isInDialogue)
        {
            //dialogue will only activate when space is pressed or if the left mouse button is pressed
            if (Input.GetKeyDown(KeyCode.Space) && !isInDialogueOptions || Input.GetMouseButtonDown(0) && !isInDialogueOptions) 
            {
                //Increments dialogue lines
                currentDialogueIndex++;
            }

            //Checks if the dialogue lines being shown are within the length of the dialogue input array
            if (currentDialogueIndex < dialogueInput.Length)
            {
                //Tells the player what dialogues are being shown
                dialogueNPCNameTMP.text = dialogueName[currentDialogueIndex];
                dialogueTMP.text = dialogueInput[currentDialogueIndex];

                //when player has dialogue options do the following
                if(atWhatPointIsTheDialogueOptioninDialogue == currentDialogueIndex && !dialogueOptionChosen)
                {
                    dialogueOptionParent.SetActive(true);
                    //pause
                    isInDialogueOptions = true;
                    //display the number of dialogue options here
                    for(int i = 0; i < howManyDialogueOptions; i++)
                    {
                        //Set the number of dialogue options in the dialogue to be visible
                        dialogueOptionsGameObjects[i].SetActive(true);
                        //Re name all the dialogue options based on whats written in the text area
                        dialogueOptionText[i].text = whatAreTheDialogueOptionsText[i];
                    }
                }
            }
            else
            {
                dialogueParent.SetActive(false);
                currentDialogueIndex = 0;
                ThirdPersonMovement.isInDialogue = false;
                for (int i = 0; i < hideUI.Length; i++)
                {
                    hideUI[i].SetActive(true);
                }
                CursorManager.setCursor = false;
                cinemachineBrain.enabled = true;

                dialogueOptionParent.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasInteractiveUserInterfacePopUp?.SetActive(false);
        dialogueParent.SetActive(false);
    }
}
