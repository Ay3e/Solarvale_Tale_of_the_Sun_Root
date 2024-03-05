using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook thirdPersonCameraCinemachineFreeLook;

    private int currentPOV = 30;
    private int numberUsedToChangePOV = 1;
    private int maxPOV = 40;
    private int minPOV = 20;

    // Update is called once per frame
    void Update()
    {
        // Get the scroll wheel delta
        float scrollDelta = Input.mouseScrollDelta.y;

        // Check if the scroll wheel moved up
        if (scrollDelta > 0)
        {
            // Call function to display up
            DisplayUp();
        }
        // Check if the scroll wheel moved down
        else if (scrollDelta < 0)
        {
            // Call function to display down
            DisplayDown();
        }
    }

    void DisplayUp()
    {
        Debug.Log("Displaying Up");
        // Implement your code to display content upwards
        if (currentPOV >= maxPOV)
        {
            currentPOV = maxPOV;
        }
        else
        {
            currentPOV = currentPOV + numberUsedToChangePOV;
        }
        thirdPersonCameraCinemachineFreeLook.m_Lens.FieldOfView = currentPOV;
    }

    void DisplayDown()
    {
        Debug.Log("Displaying Down");
        // Implement your code to display content downwards
        if (currentPOV <= minPOV)
        {
            currentPOV = minPOV;
        }
        else
        {
            currentPOV = currentPOV - numberUsedToChangePOV;
        }
        thirdPersonCameraCinemachineFreeLook.m_Lens.FieldOfView = currentPOV;
    }
}
