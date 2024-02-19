using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private GameObject inventoryUserInterface;

    private bool _isPaused;
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
            inventoryUserInterface.SetActive(!inventoryUserInterface.activeSelf);

            //Step player movement

            //Freeze screen
            _isPaused = !_isPaused; // Toggle the isPaused flag
            Time.timeScale = _isPaused ? 0f : 1f; // If isPaused is true, set timeScale to 0, otherwise set it to 1
            Debug.Log(_isPaused ? "Game paused" : "Game resumed");
        }

    }
}