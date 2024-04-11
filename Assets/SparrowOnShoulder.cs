using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        if (sparrowNoOptionDialogue.GetComponent<NoOptionDialogue>().hasFinishedTalking)
        {
            Debug.Log("Sit");
            sparrowGameObject.transform.SetParent(sparrowSitLocation.transform, true);
            sparrowGameObject.transform.localPosition = Vector3.zero;
            sparrowGameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            userInterfaceGameObject.SetActive(false);
            collisionDetector.GetComponent<CollisionDetector>().enabled = false;

            canvasInteractiveUserInterfacePopUp.SetActive(false);
        }
    }
}
