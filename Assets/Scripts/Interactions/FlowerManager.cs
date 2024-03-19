using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    [SerializeField] private GameObject flowerParent;
    // Start is called before the first frame update
    void Start()
    {
        flowerParent.SetActive(true);
    }

}
