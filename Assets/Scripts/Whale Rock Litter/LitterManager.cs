


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterManager : MonoBehaviour
{
    public GameObject[] rubbishPrefabs; // Array of rubbish prefabs
    public Transform[] spawnLocations; // Array of spawn locations
    public float spawnInterval = 120f; // Spawn interval in seconds (2 minutes)

    void Start()
    {
        InvokeRepeating("SpawnRubbish", 0f, spawnInterval); // Invoke SpawnRubbish() every spawnInterval seconds
    }

    void SpawnRubbish()
    {
        // Iterate through each spawn location
        foreach (Transform spawnPoint in spawnLocations)
        {
            // Select a random rubbish prefab from the array
            GameObject selectedRubbishPrefab = rubbishPrefabs[Random.Range(0, rubbishPrefabs.Length)];

            // Instantiate the selected rubbish prefab at the spawn location with a random rotation
            GameObject spawnedRubbish = Instantiate(selectedRubbishPrefab, spawnPoint.position, Random.rotation);

            // Set the spawned rubbish as a child of the spawn location
            spawnedRubbish.transform.parent = spawnPoint;
        }
    }
}
