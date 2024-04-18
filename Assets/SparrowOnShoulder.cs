using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SparrowOnShoulder : MonoBehaviour
{
    [SerializeField] private GameObject sparrowSitLocation;
    [SerializeField] private GameObject sparrowGameObjectParent;
    [SerializeField] private GameObject sparrowGameObject;

    [SerializeField] private GameObject sparrowNoOptionDialogue;

    //Bird dialogue stuff
    [SerializeField] private GameObject userInterfaceGameObject;
    [SerializeField] private GameObject collisionDetector;
    [SerializeField] private GameObject canvasInteractiveUserInterfacePopUp;

    private bool sparrowFound = false;
    private DateTime searchStartTime;

    private void Start()
    {
        // Record the start time when the script starts (when the game object is enabled)
        searchStartTime = DateTime.Now;
    }

    private void Update()
    {
        if (sparrowNoOptionDialogue.GetComponent<NoOptionDialogue>().hasFinishedTalking)
        {

            Debug.Log("Sparrow found");
            // Set sparrowFound to true to prevent multiple submissions
            sparrowFound = true;

            // Track the event using Unity Analytics
            TrackSparrowFoundEvent();

            // Calculate the time taken to find the sparrow
            TimeSpan timeTaken = DateTime.Now - searchStartTime;
            Debug.Log("Time taken to find sparrow: " + timeTaken);

            sparrowGameObject.transform.SetParent(sparrowSitLocation.transform, true);
            sparrowGameObject.transform.localPosition = Vector3.zero;
            sparrowGameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            userInterfaceGameObject.SetActive(false);
            collisionDetector.GetComponent<CollisionDetector>().enabled = false;

            canvasInteractiveUserInterfacePopUp.SetActive(false);
        }
    }
    private void TrackSparrowFoundEvent()
    {
        // Create a dictionary to include additional parameters (if needed)
        var eventData = new Dictionary<string, object>();

        // Calculate the time taken to find the sparrow and add it to the event data
        TimeSpan timeTaken = DateTime.Now - searchStartTime;
        eventData.Add("TimeTakenInSeconds", timeTaken.TotalSeconds);

        // Log the custom event with the event data
        Analytics.CustomEvent("SparrowFound", eventData);
    }
}
