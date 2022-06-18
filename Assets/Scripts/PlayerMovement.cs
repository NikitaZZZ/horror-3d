using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // private bool ShouldCroch => Input.GetKeyDown(crouchKey) && isGrounded;

    [SerializeField] public CharacterController controller;

    [SerializeField] public float speed = 12f;
    [SerializeField] public float gravity = -9.81f;
    [SerializeField] public float jumpHeight = 3f;

    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] public float groundDistance = 0.4f;

    private Vector3 velocity;
    private bool isGrounded;

    private bool isCrouching;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.LeftControl))
            HandleCrouch();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

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

    // private IEnumerator CrochStand()
    // {
    //     if (isCrouching && Physics.Raycast(GameObject.Find("Main Camera").transform.position, Vector3.up, 1f))
    //         yield break;

    //     float timeElapsed = 0;
    //     float targetHeight = isCrouching ? standingHeight : crouchHeight;
    //     float currentHeight = controller.height;
    //     Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
    //     Vector3 currentCenter = controller.center;

    //     while (timeElapsed < timeToCrouch)
    //     {
    //         controller.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
    //         controller.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToCrouch);
    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     controller.height = targetHeight;
    //     controller.center = targetCenter;

    //     isCrouching = !isCrouching;
    // }
}