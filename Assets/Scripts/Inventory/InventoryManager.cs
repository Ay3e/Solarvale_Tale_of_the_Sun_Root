using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private GameObject inventoryUserInterface;
    [SerializeField] private GameObject submitButton;

    private bool _isPaused;
    public ItemSlot[] itemSlot;
    public static int lupineAmount;

    public static bool turnInventoryOn;
    public static bool submitButtonOn;

    [Header("Materials")]
    [SerializeField] private GameObject buttonMaterialsTab;

    [Header("Album")]
    [SerializeField] private GameObject buttonAlbumTab;


    private void Start()
    {
        inventoryUserInterface.SetActive(false);
        submitButton.SetActive(false);
        buttonMaterialsTab.SetActive(true);
        buttonAlbumTab.SetActive(false);
    }

    private void Update()
    {
        //textMeshProLupineAmount.text = lupineAmount.ToString();
        if (Input.GetKeyDown(KeyCode.B) && !ThirdPersonMovement.isInDialogue)
        {
            if (turnInventoryOn)
            {
                submitButton.SetActive(true);
            }
            CursorManager.setCursor = !CursorManager.setCursor;
            inventoryUserInterface.SetActive(!inventoryUserInterface.activeSelf);

            //Step player movement

            //Freeze screen
            _isPaused = !_isPaused; // Toggle the isPaused flag
            Time.timeScale = _isPaused ? 0f : 1f; // If isPaused is true, set timeScale to 0, otherwise set it to 1
            Debug.Log(_isPaused ? "Game paused" : "Game resumed");
        }

        if (turnInventoryOn && ThirdPersonMovement.isInDialogue)
        {
            if (submitButtonOn)
            {
                submitButton.SetActive(true);
            }
            inventoryUserInterface.SetActive(true);
        }
        if(!turnInventoryOn && ThirdPersonMovement.isInDialogue)
        {
            submitButton.SetActive(false) ;
            inventoryUserInterface.SetActive(false);
        }
    }

    public int AddItem(string nameOfInteract, int quantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log("item Name = " + nameOfInteract + "quantity = " + quantity);

        for(int i = 0; i < itemSlot.Length; i++)
        {
            Debug.Log(itemSlot[i].isFull);
            if (itemSlot[i].isFull == false && itemSlot[i].nameOfInteract == nameOfInteract || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(nameOfInteract, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                
                    leftOverItems = AddItem(nameOfInteract, leftOverItems, itemSprite, itemDescription);
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for(int i = 0;i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void RemoveFirstItem()
    {
        if (itemSlot.Length > 0)
        {
            // Create a new array with length one less than the current array
            ItemSlot[] newItemSlot = new ItemSlot[itemSlot.Length - 1];

            // Shift elements to remove the first item
            for (int i = 0; i < newItemSlot.Length; i++)
            {
                newItemSlot[i] = itemSlot[i + 1];
            }

            // Set the last element to null to remove it
            itemSlot = newItemSlot;
        }
    }

    public void ButtonMaterial()
    {
        buttonMaterialsTab.SetActive(true);
        buttonAlbumTab.SetActive(false);
    }

    public void ButtonAlbum()
    {
        buttonMaterialsTab.SetActive(false);
        buttonAlbumTab.SetActive(true);
    }
}