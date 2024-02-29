using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private GameObject inventoryUserInterface;

    private bool _isPaused;
    public ItemSlot[] itemSlot;
    public static int lupineAmount;


    private void Start()
    {
        inventoryUserInterface.SetActive(false);
    }

    private void Update()
    {
        //textMeshProLupineAmount.text = lupineAmount.ToString();
        if (Input.GetKeyDown(KeyCode.B))
        {
            CursorManager.setCursor = !CursorManager.setCursor;
            inventoryUserInterface.SetActive(!inventoryUserInterface.activeSelf);

            //Step player movement

            //Freeze screen
            _isPaused = !_isPaused; // Toggle the isPaused flag
            Time.timeScale = _isPaused ? 0f : 1f; // If isPaused is true, set timeScale to 0, otherwise set it to 1
            Debug.Log(_isPaused ? "Game paused" : "Game resumed");
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
}