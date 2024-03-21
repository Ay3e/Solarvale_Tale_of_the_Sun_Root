using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject pickUpUserInterfaceGameObject;
    private bool _isPlayerInTrigger;

    private void Update()
    {
        if (_isPlayerInTrigger)
        {
            pickUpUserInterfaceGameObject.SetActive(true);
        }
        else
        {
            pickUpUserInterfaceGameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isPlayerInTrigger = false;
    }
}
