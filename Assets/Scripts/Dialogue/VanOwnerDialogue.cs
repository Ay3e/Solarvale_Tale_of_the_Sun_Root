using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VanOwnerDialogue : MonoBehaviour
{
    private bool isPlayerInTrigger;

    [SerializeField] private string nameOfNPC;

    [SerializeField] private GameObject displayUI;

    [SerializeField] private TextMeshProUGUI textMeshProPlantName;

    [SerializeField] private GameObject nPCDialogue;


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger)
        {
            PlayerInTriggerAction();
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Display NPC Dialogue
                nPCDialogue.SetActive(true);

                if(InventoryManager.lupineAmount >= 5)
                {
                    InventoryManager.lupineAmount = InventoryManager.lupineAmount - 5;
                }

                //Check if player have enough Lupines 
                //if they have enough take them and give them a new different plant
            }
        }
        else
        {
            PlayerNotInTriggerAction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInTrigger = false;
    }

    void PlayerInTriggerAction()
    {
        Debug.Log("In Trigger");
        displayUI.SetActive(true);
        textMeshProPlantName.text = nameOfNPC;
    }

    void PlayerNotInTriggerAction()
    {
        displayUI.SetActive(false);
        nPCDialogue.SetActive(false);
    }
}
