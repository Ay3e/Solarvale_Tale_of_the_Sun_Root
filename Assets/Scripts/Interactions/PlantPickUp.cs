using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantPickUp : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject canvasInteractiveUserInterfacePopUp;
    [SerializeField] private string nameOfInteract;
    [SerializeField] private TextMeshProUGUI nameOfInteractTMP;


    // Update is called once per frame
    void Update()
    {
        //When player is in trigger displayUI;
        canvasInteractiveUserInterfacePopUp.SetActive(true);
        nameOfInteractTMP.text = nameOfInteract;
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Lupine UI
            InventoryManager.lupineAmount++;
            //Display Lupine Fact
            canvasInteractiveUserInterfacePopUp?.SetActive(false);
            parentObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasInteractiveUserInterfacePopUp?.SetActive(false);
    }
}
