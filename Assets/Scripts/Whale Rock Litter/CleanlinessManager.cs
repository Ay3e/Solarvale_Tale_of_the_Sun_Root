using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    }
}
