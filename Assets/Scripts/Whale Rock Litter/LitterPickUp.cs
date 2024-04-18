using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class LitterPickUp : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject canvasInteractiveUserInterfacePopUp;
    [SerializeField] private string nameOfInteract;
    [SerializeField] private TextMeshProUGUI nameOfInteractTMP;

    private int numberOfLitterPickedUp = 0;

    void Update()
    {

        //When player is in trigger displayUI;
        canvasInteractiveUserInterfacePopUp.SetActive(true);
        nameOfInteractTMP.text = nameOfInteract;

        if (Input.GetKeyDown(KeyCode.E))
        {
            numberOfLitterPickedUp++;
            Analytics.CustomEvent("Litter picked up: ", new Dictionary<string, object>
        {
            { "Litter picked up: ", numberOfLitterPickedUp }
        });
            parentObject.SetActive(false);
            canvasInteractiveUserInterfacePopUp?.SetActive(false);
            //Instead of destroying the object change the object
            Debug.Log("Trash Picked Up");
            LitterManager.activeSpawnersCount--;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasInteractiveUserInterfacePopUp?.SetActive(false);
    }
}
