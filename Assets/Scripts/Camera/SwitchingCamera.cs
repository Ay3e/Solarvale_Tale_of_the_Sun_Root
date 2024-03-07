using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class SwitchingCamera : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject firstPersonCamera;

    public static bool isThirdPersonCameraActive;

    private bool switchDelay = false;
    private void Start()
    {
        isThirdPersonCameraActive = true;
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && !switchDelay)
        {
            StartCoroutine(SwitchCameraWithDelay());
        }
    }

    IEnumerator SwitchCameraWithDelay()
    {
        switchDelay = true;
        yield return new WaitForSeconds(0.3f); // Adjust the delay time here
        isThirdPersonCameraActive = !thirdPersonCamera.activeSelf;
        thirdPersonCamera.SetActive(!thirdPersonCamera.activeSelf);
        firstPersonCamera.SetActive(!thirdPersonCamera.activeSelf);
        switchDelay = false;
    }
}
