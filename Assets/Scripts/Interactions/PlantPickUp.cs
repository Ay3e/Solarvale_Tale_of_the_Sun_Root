using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantPickUp : MonoBehaviour
{
    private bool isPlayerInTrigger;

    [SerializeField] private string nameOfPlant;

    [SerializeField] private GameObject displayUI;

    [SerializeField] private TextMeshProUGUI textMeshProPlantName;

    [SerializeField] private GameObject lupineMaterialFact;


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger)
        {
            PlayerInTriggerAction();
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlayerNotInTriggerAction();
                //Lupine UI
                InventoryManager.lupineAmount++;
                //Display Lupine Fact
                lupineMaterialFact.SetActive(true);
                gameObject.SetActive(false);
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
        textMeshProPlantName.text = nameOfPlant;
    }

    void PlayerNotInTriggerAction()
    {
        displayUI.SetActive(false);
    }
}
