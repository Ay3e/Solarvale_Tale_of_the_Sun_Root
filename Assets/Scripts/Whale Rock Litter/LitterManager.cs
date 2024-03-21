using UnityEngine;

public class LitterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] rubbishPrefabs; // Array of rubbish prefabs
    [SerializeField] private GameObject[] spawnLocations;
    [SerializeField] private Transform[] spawnLocationTransform; // Array of spawn locations
    private GameObject[] spawnedRubbish;
    public static int activeSpawnersCount; // Counter for active litter spawners

    private void Update()
    {
        Debug.Log(activeSpawnersCount);
    }
    void Start()
    {
        // Initialize array to keep track of spawned rubbish objects
        spawnedRubbish = new GameObject[spawnLocations.Length];

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            spawnLocations[i].SetActive(false);
        }

        // Start the coroutine to activate random spawn locations
        StartCoroutine(RandomSpawnCoroutine());
    }

    void SpawnRubbish(int spawnLocationIndex)
    {
        // Check if the spawn location is already active
        if (!spawnLocations[spawnLocationIndex].activeSelf)
        {
            // If not, increment the active spawners count
            activeSpawnersCount++;

            // Activate the spawn location
            spawnLocations[spawnLocationIndex].SetActive(true);

            // Select a random rubbish prefab from the array
            GameObject selectedRubbishPrefab = rubbishPrefabs[Random.Range(0, rubbishPrefabs.Length)];

            // If there was already a rubbish prefab spawned at this location, destroy it
            if (spawnedRubbish[spawnLocationIndex] != null)
            {
                Destroy(spawnedRubbish[spawnLocationIndex]);
            }

            // Instantiate the selected rubbish prefab at the spawn location with a random rotation
            GameObject newSpawnedRubbish = Instantiate(selectedRubbishPrefab, spawnLocationTransform[spawnLocationIndex].position, Random.rotation);

            // Set the spawned rubbish as a child of the spawn location
            newSpawnedRubbish.transform.parent = spawnLocationTransform[spawnLocationIndex];

            // Store the spawned rubbish object in the array
            spawnedRubbish[spawnLocationIndex] = newSpawnedRubbish;
        }
    }

    System.Collections.IEnumerator RandomSpawnCoroutine()
    {
        while (true)
        {
            // Generate a random wait time between 80 and 120 seconds
            float waitTime = Random.Range(15f, 30f);

            // Wait for the random time
            yield return new WaitForSeconds(waitTime);

            // Choose a random spawn location
            int randomIndex = Random.Range(0, spawnLocations.Length);

            // Spawn rubbish at the selected spawn location
            SpawnRubbish(randomIndex);
        }
    }
}
