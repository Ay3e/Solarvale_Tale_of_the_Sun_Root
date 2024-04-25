using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparrowCall : MonoBehaviour
{
    private bool isPlayerInTriggerArea;
    [SerializeField] private AudioSource audioSparrowCalling;
    // Start is called before the first frame update
    private void Start()
    {
        // Start the coroutine to play audio every 2 seconds
        StartCoroutine(PlayAudioRepeatedly());
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerInTriggerArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInTriggerArea = false;
    }

    private System.Collections.IEnumerator PlayAudioRepeatedly()
    {
        while (true)
        {
            // Check if the player is in the trigger area
            if (isPlayerInTriggerArea)
            {
                // Play the audio
                audioSparrowCalling.Play();

                // Wait for a random duration between 1 and 2 seconds before playing again
                float randomInterval = Random.Range(1.5f, 2.5f);
                yield return new WaitForSeconds(randomInterval);
            }
            else
            {
                // If the player is not in the trigger area, wait for the next frame
                yield return null;
            }
        }
    }
}
