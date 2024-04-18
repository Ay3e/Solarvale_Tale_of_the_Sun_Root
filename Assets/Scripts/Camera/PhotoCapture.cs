using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashingTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Hide all UI")]
    [SerializeField] private GameObject[] hideUI;
    [SerializeField] private GameObject[] takePhotoUI;
    [SerializeField] private GameObject plusUI;

    [SerializeField] private GameObject albumSlots;

    private Texture2D screenCapture;
    private bool viewingPhoto;

    [Header("Analytics Details")]
    private int numberOfPhotosCaptured = 0;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (SwitchingCamera.isThirdPersonCameraActive == false)
        {
            for(int i = 0; i < takePhotoUI.Length; i++)
            {
                takePhotoUI[i].SetActive(true);

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!viewingPhoto)
                {
                    //Take Screenshot;
                    StartCoroutine(CapturePhoto());
                }
                else
                {
                    RemovePhoto();
                }

            }
        }
        else
        {
            RemovePhoto();
        }
    }

    IEnumerator CapturePhoto()
    {
        //Analytics
        numberOfPhotosCaptured++;
        Debug.Log("numberOfPhotosCaptured: " + numberOfPhotosCaptured);
        Analytics.CustomEvent("Photo Captured", new Dictionary<string, object>
        {
            { "Number of Photos Captured", numberOfPhotosCaptured }
        });

        // Set all UI to false
        foreach (var ui in hideUI)
        {
            ui.SetActive(false);
        }

        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        // Use RGBA32 format for screen capture
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBA32, false);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();

        yield return new WaitForSeconds(1f); // Cooldown period
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        // Start other effects/animations
        photoFrame.SetActive(true);
        StartCoroutine(CameraFlashEffect());
        fadingAnimation.Play("PhotoFade");
        plusUI.SetActive(false);

        StartCoroutine(DelayedClone());
    }

    IEnumerator DelayedClone()
    {
        yield return new WaitForSeconds(1f); // Wait for one second

        // Create a clone of the photoFrame and its children
        GameObject photoFrameClone = Instantiate(photoFrame, albumSlots.transform);

        photoFrameClone.transform.localScale = Vector3.one * 0.25f;
        // Activate the photoFrame clone
        photoFrameClone.SetActive(true);
    }

    IEnumerator CameraFlashEffect()
    {
        for (int i = 0; i < hideUI.Length; i++)
        {
            hideUI[i].SetActive(true);
        }
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashingTime);
        cameraFlash.SetActive(false);
    }

    void RemovePhoto()
    {

        plusUI.SetActive(true);
        for (int i = 0; i < takePhotoUI.Length; i++)
        {
            takePhotoUI[i].SetActive(false);
        }
        viewingPhoto = false;
        photoFrame.SetActive(false);
    }
}
