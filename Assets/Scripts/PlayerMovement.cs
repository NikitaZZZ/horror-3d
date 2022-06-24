using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public CharacterController controller;

    [SerializeField] public float speed = 3f;
    [SerializeField] public float gravity = -9.81f;
    [SerializeField] public float jumpHeight = 3f;

    [SerializeField] public Rigidbody rb;

    private Vector3 velocity;
    private bool isCrouching;

    private bool isSprint = false;
    private bool isCanSprint = true;

    private float stamina = 100f;

    public Slider slider;

    private bool isMoving = false;

    private bool checkKeyPress;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            HandleCrouch();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (stamina >= 100)
        {
            isCanSprint = true;
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        }
        
        if (stamina < 100)
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;           

        if (stamina > 0) isCanSprint = true;

        if (isSprint && stamina > 0)
        {
            if (x > 0 || z > 0)
            {
                stamina -= 0.15f;
                slider.value = stamina;
            } else {
                isSprint = !isSprint;
            }
        }

        if (!isSprint && stamina <= 100)
        {
            stamina += 0.02f;
            slider.value = stamina;
        }

        if (stamina <= 0) {
            isCanSprint = false;
            isSprint = false;
            speed = 5f;
        }

        if (isCanSprint && Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprint = !isSprint;

            if (isSprint) speed = 10f;
            else speed = 5f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleCrouch() 
    { 
        isCrouching = !isCrouching;

        if (isCrouching)
            controller.height = 0.5f;
        else
            controller.height = 1.6f;
    }
}