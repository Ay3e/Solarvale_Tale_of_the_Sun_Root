using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MaterialsManager : MonoBehaviour
{
    //What needs to be updated everytime player clicks on a material
    [SerializeField] private TextMeshProUGUI itemNameTextTMP;
    [SerializeField] private TextMeshProUGUI detailsTextTMP;
    
    public void ButtonLupine()
    {
        itemNameTextTMP.text = "Lupine";
        detailsTextTMP.text = "Lupines are stunning plants with tall spikes, colourful blooms, and palate leaves. They're widespread across the globe and improve soil health through nitrogen fixation.";
    }

    public void ButtonCrocus()
    {
        itemNameTextTMP.text = "Crocus";
        detailsTextTMP.text = "Crocus, known for its vibrant blooms, yields saffron, a prized spice used in both culinary and believed to have health benefits to treat several ailments.";
    }
}
