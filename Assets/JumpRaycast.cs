using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRaycast : MonoBehaviour
{
    public bool grounded = false;
    public float groundCheckDistance;
    private float bufferCheckDistance = 0.1f;
    void Update()
    {
        groundCheckDistance = (GetComponent<CharacterController>().height / 2) + bufferCheckDistance;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 100, ForceMode.Impulse);
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
