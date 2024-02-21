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
    private InventoryManager inventoryManager;

    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    [TextArea][SerializeField] private string itemDescription;


    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
    }


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

            inventoryManager.AddItem(nameOfInteract, quantity, sprite, itemDescription);

            canvasInteractiveUserInterfacePopUp?.SetActive(false);
            parentObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasInteractiveUserInterfacePopUp?.SetActive(false);
    }
}
