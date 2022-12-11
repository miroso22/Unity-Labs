using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    private int horizontalSpeed = 15;
    private int jumpSpeed = 20;
    private float gravityMultiplier = 0.05f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        movement.x = 0;
        movement.z = 0;
        if (Input.GetKey("a"))
        {
            movement.x = -horizontalSpeed;
        }
        if (Input.GetKey("d"))
        {
            movement.x = horizontalSpeed;
        }
        if (Input.GetKey("w"))
        {
            movement.z = horizontalSpeed;
        }
        if (Input.GetKey("s"))
        {
            movement.z = -horizontalSpeed;
        }
        if (controller.isGrounded && Input.GetKey("space"))
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