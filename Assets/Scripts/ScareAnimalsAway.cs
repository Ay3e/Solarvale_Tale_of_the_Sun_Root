using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareAnimalsAway : MonoBehaviour
{
    private bool isPlayerInTriggerArea;
    [SerializeField] private GameObject animalMesh;
    void Update()
    {
        if(isPlayerInTriggerArea && ThirdPersonMovement.isSprinting)
        {
            // Animal runaway
            animalMesh.SetActive(false);
        }

        if(isPlayerInTriggerArea == false)
        {
            animalMesh.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isPlayerInTriggerArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInTriggerArea = false;
    }
}
