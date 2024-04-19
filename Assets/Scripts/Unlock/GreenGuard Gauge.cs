using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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

            // Activate GreenGuard UI
            greenGuardUI.SetActive(true);

            // Track the event using Unity Analytics
            TrackGreenGuardActivatedEvent();
        }
    }
    private void TrackGreenGuardActivatedEvent()
    {
        Analytics.CustomEvent("GreenGuardActivated");
    }
}
