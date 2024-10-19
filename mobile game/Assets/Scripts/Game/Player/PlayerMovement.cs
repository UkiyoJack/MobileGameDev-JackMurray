using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigidBody2d;
    private Vector2 movementInput;
    private Vector2 smoothedMovementinput;
    private Vector2 smoothedVelocity;

    
    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementinput = Vector2.SmoothDamp(
                    smoothedMovementinput,
                    movementInput,
                    ref smoothedVelocity,
                    0.1f);

        rigidBody2d.velocity = smoothedMovementinput * speed;
    }

    private void RotateInDirectionOfInput()
    {
        if(movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementinput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 

            rigidBody2d.MoveRotation(rotation);
        }
    }
    private void OnMove(InputValue inputvalue)
    {
        movementInput = inputvalue.Get<Vector2>();

    }
}
