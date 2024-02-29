using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Item data

    public string nameOfInteract;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    [SerializeField] private TextMeshProUGUI quantityText;

    [SerializeField] private Image itemImage;

    public Image itemDescriptionImage;
    public TextMeshProUGUI itemDescriptionNameText;
    public TextMeshProUGUI itemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    [SerializeField] private int maxNumberOfItems;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
    }
    public int AddItem(string nameOfInteract, int quantity, Sprite itemSprite, string itemDescription)
    {
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
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        itemDescriptionNameText.text = nameOfInteract;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

    public void OnRightClick()
    {

    }
}
