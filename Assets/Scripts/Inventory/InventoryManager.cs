using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProLupineAmount;

    [SerializeField] private GameObject BagUI;

    public static int lupineAmount;


    private void Update()
    {
        textMeshProLupineAmount.text = lupineAmount.ToString();

        if (Input.GetKeyDown(KeyCode.B))
        {
            BagUI.SetActive(!BagUI.activeSelf);
        }
    }
}