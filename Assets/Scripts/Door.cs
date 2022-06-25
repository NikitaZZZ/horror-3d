// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Door : Interactable
// {
//     private bool isOpen = false;
//     private bool canBeInteractedWith = false;
//     private Animator anim;

//     public override void OnFocus()
//     {
//         anim = GetComponent<Animator>();
//     }

//     public override void OnInteract()
//     {
//         if (canBeInteractedWith)
//         {
//             isOpen = !isOpen;

//             Vector3 doorTransformDirection = transform.TransformDirection(Vector3.forward);
//             Vector3 playerTransformDirection = PlayerMovement.instance.transform.position - transform.position;
//             float dot = Vector3.dot(doorTransformDirection, playerTransformDirection);

//             anim.SetFloat("dot", dot);
//             anim.SetBool("isOpen", isOpen);
//         }
//     }

//     public override void OnLoseFocus()
//     {

//     }
// }
