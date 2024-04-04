using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirthdayDialogue : MonoBehaviour
{
    [SerializeField] private string nameOfInteract;

    [Header("Dialogue Functions")]
    [TextArea][SerializeField] private string[] dialogueInput;
    [TextArea][SerializeField] private string[] dialogueName;
    [SerializeField] private TextMeshProUGUI dialogueTMP;
    [SerializeField] private TextMeshProUGUI dialogueNPCNameTMP;
    public static int currentDialogueIndex = 0;

    [Header("Hide UI")]
    [SerializeField] private GameObject[] hideUI;


    void Update()
    {
        //dialogue will only activate when space is pressed or if the left mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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

        }
        else
        {
            //Load new scene
            LoadScene();
        }
    }

    public void LoadScene()
    {
        // Load the scene with the specified name
        SceneManager.LoadScene(1);
    }


}
