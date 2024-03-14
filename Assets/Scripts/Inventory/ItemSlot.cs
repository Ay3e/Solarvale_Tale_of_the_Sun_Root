using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Item data

    public GameObject buttonAndItemImageOfItemSlot;

    public string nameOfInteract;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    [SerializeField] private TextMeshProUGUI quantityText;

    [SerializeField] private UnityEngine.UI.Image itemImage;

    public UnityEngine.UI.Image itemDescriptionImage;
    public TextMeshProUGUI itemDescriptionNameText;
    public TextMeshProUGUI itemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    [SerializeField] private int maxNumberOfItems;

    public static bool submitButtonIsPressed;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
    }
    public int AddItem(string nameOfInteract, int quantity, Sprite itemSprite, string itemDescription)
    {
        //When Item is picked display Button and Item Image of Item Slot
        buttonAndItemImageOfItemSlot.SetActive(true);

        //Check to see if the slot is already full
        if (isFull)
            return quantity;
        //Update NAME
        this.nameOfInteract = nameOfInteract;


        //Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //Update Description
        this.itemDescription = itemDescription;

        //Update QUANTITY
        this.quantity += quantity;
        if(this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
            //Return the LEFTOVERS
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Update QUANTITY TEXT
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button== PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        //InventoryManager.turnInventoryOn = false;

        UseSelectedItem();

        if (!thisItemSelected)
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemDescriptionNameText.text = nameOfInteract;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
        }
    }

    public void OnRightClick()
    {

    }
    public void SubmitButton()
    {

        Debug.Log("Submit button pressed");
        //Item has been used then get out of dialogue
        InventoryManager.turnInventoryOn = false;

        SickGuyDialogue.isInDialogueOptions = false;
        SickGuyDialogue.currentDialogueIndex++;
        SickGuyDialogue.dialogueOptionChosen = false;

        //Disable
    }

    private void UseSelectedItem()
    {
        if (thisItemSelected && ThirdPersonMovement.isInDialogue)
        {
            //UseItem
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }

            //Display submit button
            InventoryManager.submitButtonOn = true;
        }
    }

    private void EmptySlot()
    {
        //When this gameObject is destroyed remove this array position from the Inventory Manager
        Destroy(buttonAndItemImageOfItemSlot);
        inventoryManager.RemoveFirstItem();

        quantityText.enabled = false;
        itemImage.sprite = null;
        itemDescription = "";
        nameOfInteract = "";

        itemDescriptionNameText.text = nameOfInteract;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = null;
        itemSprite = null;
    }
}
