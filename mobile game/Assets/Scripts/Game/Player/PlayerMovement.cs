using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f ;

    [SerializeField]
    private float rotationSpeed = 200f;

    private Rigidbody2D rigidBody2d;
    private Vector2 movementInput;
    private Vector2 smoothedMovementinput;
    private Vector2 smoothedVelocity;


    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();

        if (SystemInfo.supportsGyroscope )
        {
            Input.gyro.enabled = true;      //enable gyroscope if device has support
        }
    }

    private void FixedUpdate()
    {
        /*SetPlayerVelocity();
        RotateInDirectionOfInput();*/

        if (SystemInfo.supportsGyroscope)
        {
            Vector2 tilt = Input.gyro.gravity; //get gyro grav data

            movementInput = new Vector2(tilt.x, tilt.y);

            /*gyroMovement(tilt); //call gyro movement method
            gyroRotation(tilt); //call gyro */

            SetPlayerVelocity();
            RotateInDirectionOfInput();
        }
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementinput = Vector2.SmoothDamp(
                    smoothedMovementinput,
                    movementInput,
                    ref smoothedVelocity,
                    0.1f);
         
        rigidBody2d.velocity = smoothedMovementinput * speed; //set players velocity based on smoothed input
    }

    private void RotateInDirectionOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg - 90f; //use Atan2 to calculate angle to rotate player

            Quaternion targetRotation = Quaternion.Euler(0,0, angle);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rigidBody2d.MoveRotation(rotation);
        }
    }
    /*private void OnMove(InputValue inputvalue)
    {
        movementInput = inputvalue.Get<Vector2>();

    }*/
}
