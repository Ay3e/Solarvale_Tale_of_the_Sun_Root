using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPeronController : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0f; // Ensure no vertical movement

        // Calculate the target velocity based on the moveDirection and desired speed
        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;

        // Calculate the change in velocity required to reach the target velocity in one fixed timestep
        Vector3 velocityChange = (targetVelocity - rb.velocity);

        // Apply the calculated velocity change to the rigidbody
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
