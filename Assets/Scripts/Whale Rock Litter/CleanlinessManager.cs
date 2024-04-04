using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class CleanlinessManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cleanlinessPercentageText;
    [SerializeField] private Image cleanlinessCircleIcon;
    [SerializeField] private GameObject[] spawnLocations;

    private float activeSpawnCounter;
    private float spawnLocationArrayLength;

    private float cleanlinessDecimalLessThanOneHundredSmooth;
    private float cleanlinessDecimalLessThanOneSmooth;
    private float transitionSpeed = 5f;

    void Update()
    {
        activeSpawnCounter = LitterManager.activeSpawnersCount;
        spawnLocationArrayLength = (float)spawnLocations.Length;

        float cleanlinessDecimalLessThanOneHundredTarget = 100f * (activeSpawnCounter / spawnLocationArrayLength);
        cleanlinessDecimalLessThanOneHundredTarget = 100f - cleanlinessDecimalLessThanOneHundredTarget;

        cleanlinessDecimalLessThanOneHundredSmooth = Mathf.Lerp(cleanlinessDecimalLessThanOneHundredSmooth, cleanlinessDecimalLessThanOneHundredTarget, Time.deltaTime * transitionSpeed);
        int roundedPercentage = Mathf.RoundToInt(cleanlinessDecimalLessThanOneHundredSmooth);
        cleanlinessPercentageText.text = roundedPercentage.ToString() + "%";

        float cleanlinessDecimalLessThanOneTarget = 1f * (activeSpawnCounter / spawnLocationArrayLength);
        cleanlinessDecimalLessThanOneTarget = 1f - cleanlinessDecimalLessThanOneTarget;

        cleanlinessDecimalLessThanOneSmooth = Mathf.Lerp(cleanlinessDecimalLessThanOneSmooth, cleanlinessDecimalLessThanOneTarget, Time.deltaTime * transitionSpeed);
        cleanlinessCircleIcon.fillAmount = cleanlinessDecimalLessThanOneSmooth;

        if (roundedPercentage >= 60)
        {
            // Green (20B946)
            cleanlinessCircleIcon.color = new Color(32f / 255f, 185f / 255f, 70f / 255f);
        }
        else if (roundedPercentage < 60 && roundedPercentage >= 20)
        {
            // Yellow (E7D138)
            cleanlinessCircleIcon.color = new Color(231f / 255f, 209f / 255f, 56f / 255f);
        }
        else if (roundedPercentage < 20)
        {
            // Red (E73E38)
            cleanlinessCircleIcon.color = new Color(231f / 255f, 62f / 255f, 56f / 255f);
        }
    }
}
