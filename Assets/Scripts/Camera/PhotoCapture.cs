using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject takePhotoUI;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (SwitchingCamera.isThirdPersonCameraActive == false)
        {
            takePhotoUI.SetActive(true);
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
        //Set all Ui to false

        for(int i = 0; i < hideUI.Length; i++)
        {
            hideUI[i].SetActive(false);
        }

        viewingPhoto = true;
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
        StartCoroutine(CameraFlashEffect());

        fadingAnimation.Play("PhotoFade");
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
        takePhotoUI.SetActive(false);
        viewingPhoto = false;
        photoFrame.SetActive(false);

    }
}
