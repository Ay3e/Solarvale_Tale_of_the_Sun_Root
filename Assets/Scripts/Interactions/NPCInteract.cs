using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject canvasInteractiveUserInterfacePopUp;
    [SerializeField] private string nameOfInteract;
    [SerializeField] private TextMeshProUGUI nameOfInteractTMP;

    void Update()
    {
        canvasInteractiveUserInterfacePopUp.SetActive(true);
        nameOfInteractTMP.text = nameOfInteract;
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }
}
