using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    //Written by ChatGPT

    [SerializeField] private Transform parentObject;
    [SerializeField] private GameObject[] objectivesTextArray;

    //Objective Names
    public static bool talkedToLaura = false;

    private void Update()
    {
        for (int i = 0; i < objectivesTextArray.Length; i++)
        {
            // Check if the TextMeshPro component of the GameObject is present
            TextMeshProUGUI textMeshPro = objectivesTextArray[i].GetComponent<TextMeshProUGUI>();

            // If TextMeshPro component is present and its text input is empty
            if (textMeshPro != null && string.IsNullOrEmpty(textMeshPro.text))
            {
                // Set the GameObject to false
                objectivesTextArray[i].SetActive(false);

                // Move the object to the end of the parent object
                objectivesTextArray[i].transform.SetAsLastSibling();
            }
            //else
            //{
            //    objectivesTextArray[i].SetActive(true);

                // Objective Stuff
                //if (textMeshPro != null && textMeshPro.text == "Talk to Laura and show her your new gift")
                //{
                    //if (talkedToLaura)
                    //{
                        // Do something if talkedToLaura is true
                        //textMeshPro.text = "";
                    //}
                //}
            //}
        }
    }
}
