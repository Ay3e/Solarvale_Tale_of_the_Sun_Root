using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static int photosTaken;
    public static float timeTakenToFindSparrow;
    public static int timesBagOpened;
    public static int flowersCollected;
    public static int trashCollected;

    private void Update()
    {
        Debug.Log("TrackDataInformation.Start");

        // Create an instance of TrackDataInformation
        TrackDataInformation trackDataInformation = new TrackDataInformation();



        // Assign the values from public static variables to the instance
        trackDataInformation.photosTaken = photosTaken;
        trackDataInformation.timeTakenToFindSparrow = timeTakenToFindSparrow;
        trackDataInformation.timesBagOpened = timesBagOpened;
        trackDataInformation.flowersCollected = flowersCollected;
        trackDataInformation.trashCollected = trashCollected;

        // Convert the TrackDataInformation instance to JSON
        string json = JsonUtility.ToJson(trackDataInformation);
        Debug.Log(json);

        // Specify the path relative to the Assets folder
        string filePath = "Assets/saveFile.json";

        // Write to the file without ensuring it's correct
        File.WriteAllText(filePath, json);
        Debug.Log("File created at: " + filePath);
    }

    // Additional methods or variables can be added as needed

    private class TrackDataInformation
    {
        // Empty constructor for JSON serialization
        public TrackDataInformation() { }

        // How many photos are being taken
        public int photosTaken;

        // How long did it take to find the sparrow
        public float timeTakenToFindSparrow;

        // How many times the player opened back
        public int timesBagOpened;

        public int flowersCollected;

        public int trashCollected;
    }
}