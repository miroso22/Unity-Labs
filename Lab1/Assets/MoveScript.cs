using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    private int horizontalSpeed = 15;
    private int jumpSpeed = 20;
    private float gravityMultiplier = 0.02f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        movement.x = 0;
        if (Input.GetKey("a"))
        {
            movement.x = -horizontalSpeed;
        }
        if (Input.GetKey("d"))
        {
            movement.x = horizontalSpeed;
        }
        if (controller.isGrounded && Input.GetKey("w"))
        {
            movement.y = jumpSpeed;
        }
        if (!controller.isGrounded)
        {
            movement.y += Physics.gravity.y * gravityMultiplier;
        }
        controller.Move(movement * Time.deltaTime);
    }
}