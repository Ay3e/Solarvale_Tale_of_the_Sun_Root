using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SickGuyDialogue : MonoBehaviour
{
    [SerializeField] private GameObject canvasInteractiveUserInterfacePopUp;
    [SerializeField] private string nameOfInteract;
    [SerializeField] private TextMeshProUGUI nameOfInteractTMP;

    //Dialogue functions
    [SerializeField] private GameObject dialogueParent;
    [TextArea][SerializeField] private string dialogueInput;
    [SerializeField] private TextMeshProUGUI dialogueTMP;
    [SerializeField] private TextMeshProUGUI dialogueNPCNameTMP;

    private void Start()
    {
        dialogueParent.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        canvasInteractiveUserInterfacePopUp.SetActive(true);
        nameOfInteractTMP.text = nameOfInteract;
        dialogueTMP.text = dialogueInput;
        dialogueNPCNameTMP.text = nameOfInteract;

        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogueParent.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasInteractiveUserInterfacePopUp?.SetActive(false);
        dialogueParent.SetActive(false);
    }
}
