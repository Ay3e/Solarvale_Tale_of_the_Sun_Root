using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameSparrowWithJackson : MonoBehaviour
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

    [Header("Dialogue Naming")]
    [SerializeField] private int atWhatPointIsNamingCompanion;
    [SerializeField] private GameObject canvasNamingCompanion;
    public static bool isInNamingCompanion = false;
    public static bool hasNameBeenConfirmed = false;


    private void Start()
    {
        dialogueParent.SetActive(false);
        canvasNamingCompanion.SetActive(false);
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
            for (int i = 0; i < hideUI.Length; i++)
            {
                hideUI[i].SetActive(false);
            }
        }

        //If player is in a dialogue scene then check for the following
        if (ThirdPersonMovement.isInDialogue)
        {
            //dialogue will only activate when space is pressed or if the left mouse button is pressed
            if (Input.GetKeyDown(KeyCode.Space) && !isInNamingCompanion || Input.GetMouseButtonDown(0) && !isInNamingCompanion)
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
                if (atWhatPointIsNamingCompanion == currentDialogueIndex && !hasNameBeenConfirmed)
                {
                    canvasNamingCompanion.SetActive(true);
                    //pause
                    isInNamingCompanion = true;
                    //display the number of dialogue options here
                }
                else
                {
                    canvasNamingCompanion.SetActive(false);
                    isInNamingCompanion = false;
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

                canvasNamingCompanion.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasInteractiveUserInterfacePopUp?.SetActive(false);
        dialogueParent.SetActive(false);
    }

    public void ConfirmNamingCompanionButton()
    {
        hasNameBeenConfirmed = true;
    }
}
