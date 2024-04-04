using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGuardGauge : MonoBehaviour
{
    [SerializeField] private GameObject greenGuardUI;

    [SerializeField] private GameObject jacqualineNoOptionDialogue;


    private void Start()
    {
        greenGuardUI.SetActive(false);
        // Assuming noOptionDialogue is assigned in the Unity Editor
    }

    private void Update()
    {
        if (jacqualineNoOptionDialogue.GetComponent<NoOptionDialogue>().hasFinishedTalking)
        {
            greenGuardUI.SetActive(true);
        }
    }
}
