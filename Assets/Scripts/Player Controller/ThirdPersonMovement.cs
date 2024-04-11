using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;

    [SerializeField] private Animator animator;


    float turnSmoothVelocity;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float gravity = 20f; // Adjust gravity as per your needs
    [SerializeField] private float jumpForce = 8f; // Adjust jump force as per your needs
    [SerializeField] private float speedMultiplier = 2.0f;

    private float verticalVelocity = 0f;

    private float stamina = 7f;
    private float staminaMax = 7f;
    private bool playerHasExhausted = false;

    public Slider staminaBar;
    [SerializeField] private GameObject staminaGameObject;

    [SerializeField] private GameObject cameraCameraFirstPerson;

    public static bool isInDialogue;

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

        if (direction.magnitude >= 0.1f && !ThirdPersonMovement.isInDialogue)
        {
            animator.SetBool("isWalking", true);
            //Third Person Y
            if (SwitchingCamera.isThirdPersonCameraActive == true)
            {
                animator.speed = speedMultiplier;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            else
            {

                float targetAngle = cameraCameraFirstPerson.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                // Get character's forward direction (excluding vertical component)
                Vector3 characterForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;
                // Get character's right direction (excluding vertical component)
                Vector3 characterRight = Vector3.Scale(transform.right, new Vector3(1, 0, 1)).normalized;

                // Calculate movement direction based on input
                Vector3 moveDir = characterForward * vertical + characterRight * horizontal;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            //player can sprint when player has stamina and they had not been exhausted before 

            if (!playerHasExhausted && SwitchingCamera.isThirdPersonCameraActive == true)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    staminaGameObject.SetActive(true);
                    //player sprints
                    animator.speed = speedMultiplier*2;
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
                    animator.speed = speedMultiplier;
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
                animator.speed = speedMultiplier;
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
            if (Input.GetKey(KeyCode.Space) && controller.isGrounded && !isInDialogue)
            {
                // Perform the jump
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
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
            if (Input.GetKey(KeyCode.Space) && controller.isGrounded && !isInDialogue)
            {
                // Perform the jump
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
