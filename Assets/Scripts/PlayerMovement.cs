using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public CharacterController controller;

    [SerializeField] public float speed = 5f;
    [SerializeField] public float gravity = -9.81f;
    [SerializeField] public float jumpHeight = 3f;

    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] public float groundDistance = 0.4f;

    [SerializeField] private ValueSystem _healthSystem = new ValueSystem();

    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching;

    private bool isSprint = false;
    private bool isCanSprint = true;

    private float stamina = 100f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.LeftControl))
            HandleCrouch();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (stamina >= 100)
            isCanSprint = true;

        if (isSprint && stamina > 0)
            stamina -= 0.01f;
        if (!isSprint && stamina <= 100)
            stamina += 0.02f;

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

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

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

    private void Start()
    {
        _healthSystem.Setup(500);

        Invoke(nameof(AppleDamage), 2f);
    }

    private void AppleDamage()
    {
        _healthSystem.RemoveValue(120);
    }
}