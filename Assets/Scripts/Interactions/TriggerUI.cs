using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    public string playerTag = "Player"; // Tag to identify player GameObjects
    public Collider[] triggerList;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && IsInTriggerList(other))
        {
            Debug.Log("Hello World");
            // You can perform any other actions here
        }
    }

    private bool IsInTriggerList(Collider collider)
    {
        foreach (Collider triggerCollider in triggerList)
        {
            if (collider == triggerCollider)
            {
                return true;
            }
        }
        return false;
    }
}
