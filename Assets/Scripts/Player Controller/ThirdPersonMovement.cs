using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    [SerializeField] private Animator animator;


    float turnSmoothVelocity;

    public float speed = 12f;
    public float turnSmoothTime = 0.1f;
    public float gravity = 20f; // Adjust gravity as per your needs
    public float jumpForce = 8f; // Adjust jump force as per your needs

    private float verticalVelocity = 0f;

    private float stamina = 7f;
    private float staminaMax = 7f;
    private bool playerHasExhausted = false;

    public Slider staminaBar;
    [SerializeField] private GameObject staminaGameObject;
    public float dValue;

    private void Start()
    {
        staminaMax = stamina;
        staminaBar.maxValue = staminaMax;
        staminaGameObject.SetActive(false);
    }

    void Update()
    {
        staminaBar.value = stamina;
        //Debug.Log(stamina);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //player can sprint when player has stamina and they had not been exhausted before 

            if (!playerHasExhausted)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    staminaGameObject.SetActive(true);
                    //player sprints
                    speed = 24f;
                    //when player sprints they lose stamina
                    stamina = stamina - Time.deltaTime;
                    //when player loses more than 6 seconds of stamina 
                    if (stamina <= 0)
                    {
                        //become exhausted
                        playerHasExhausted = true;
                    }
                }
                else
                {
                    speed = 12f;
                    if (stamina >= staminaMax)
                    {
                        stamina = staminaMax;
                        staminaGameObject.SetActive (false);
                    }
                    else
                    {
                        stamina = stamina + Time.deltaTime;
                    }
                }
            }
            else
            {
                speed = 12f;
                if (stamina >= staminaMax)
                {
                    stamina = staminaMax;
                    staminaGameObject.SetActive (false);
                }
                else
                {
                    stamina = stamina + Time.deltaTime;
                }
            }


            //if shift has been released player is not exhausted
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerHasExhausted = false;
            }
            // Check for jump input when moving
            if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            speed = 12f;
            if (stamina >= staminaMax)
            {
                stamina = staminaMax;
                staminaGameObject.SetActive (false);
            }
            else
            {
                stamina = stamina + Time.deltaTime;
            }
            // Check for jump input when not moving
            if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
            {
                verticalVelocity = jumpForce;
            }
        }
        if (!controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        controller.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);


    }
}
