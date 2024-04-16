using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    //Written by ChatGPT

    [SerializeField] private Transform parentObject;
    [SerializeField] private GameObject[] objectivesTextArray;

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
            else{
                objectivesTextArray[i].SetActive(true);
            }
        }
    }
}
