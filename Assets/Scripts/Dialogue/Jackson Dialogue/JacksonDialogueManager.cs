using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JacksonDialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject userInterfaceGameObjectHaventFoundBird;
    [SerializeField] private GameObject userInterfaceGameObjectHasFoundBird;
    private void Update()
    {
        if(SparrowOnShoulder.sparrowFound == true)
        {
            userInterfaceGameObjectHaventFoundBird.SetActive(false);
            userInterfaceGameObjectHasFoundBird.SetActive(true);   
        }
        else
        {
            userInterfaceGameObjectHaventFoundBird.SetActive(true);
            userInterfaceGameObjectHasFoundBird.SetActive(false);
        }
    }
}
