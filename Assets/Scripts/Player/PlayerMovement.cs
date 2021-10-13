using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalSpeed = 1.0f;
    public float verticalSpeed = 1.0f;
    public float flyingSpeed = 2.0f;
    public float jumpHeight = 3.0f;

    public float gravityValue = -15.0f;

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity = Vector3.zero;
    bool isGrounded = false;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }          

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = vectorToSanitize(transform.right) * x * horizontalSpeed + vectorToSanitize(transform.forward) * z * verticalSpeed;

        if (!isGrounded)
        {
            move *= flyingSpeed;
        }

        controller.Move(move * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);        
    }

    Vector3 vectorToSanitize(Vector3 vectorToSanitize)
    {
        Vector3 sanitizedVector = vectorToSanitize;
        sanitizedVector.y = 0;
        sanitizedVector.Normalize();
        return sanitizedVector;
    }
}


