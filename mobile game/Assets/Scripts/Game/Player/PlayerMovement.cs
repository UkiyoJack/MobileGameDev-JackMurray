using System;
using System.Collections;
using System.Collections.Generic;
/*using System.Diagnostics;*/
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 5;

    [SerializeField]
    private float rotationSpeed = 200f;

    private Rigidbody2D rigidBody2d;
    private Vector2 movementInput;
    private Vector2 smoothedMovementinput;
    private Vector2 smoothedVelocity;

    private ItemShopScript itemShopScript;

    Animator animator;
    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();

        /*itemShopScript = FindObjectOfType<ItemShopScript>();*/

        speed = PlayerPrefs.GetFloat("playerSpeed", 5f);
        Debug.Log($"Player speed loaded: {speed}");

        //if (SystemInfo.supportsGyroscope)
        //{
        //    Input.gyro.enabled = true;      //enable gyroscope if device has support
        //}

    }

    private void FixedUpdate()
    {
        /*SetPlayerVelocity();
        RotateInDirectionOfInput();*/

        if (Input.touchCount > 0) //touch input for mobile
        {
            Touch touch = Input.GetTouch(0);

            //get touch pos in world coords
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0; //Z axis is 0 as 2D game

            //calc direction from player to touch pos
            Vector2 dir = (touchPos - transform.position).normalized;

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                //move in touch direction (while touch is continuous)
                movementInput = dir;

                animator.SetBool("isMoving", true);
            }
            SetPlayerVelocity();
            RotateInDirectionOfInput();
            animator.SetBool("isMoving", movementInput != Vector2.zero); //if movementInput isnt ZERO, update transition in animation. (handles both true and false conditions)
        }
        else
        {
            // WASD input for debugging (desktop)
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            SetPlayerVelocity();
            RotateInDirectionOfInput();
            animator.SetBool("isMoving", movementInput != Vector2.zero);
        }
        /*if (itemShopScript != null && itemShopScript.speedBoostActive)
        {
            // Apply the speed boost
            speed = speed + itemShopScript.currentSpeedBoost;
            Debug.Log("updated speed!");
        }
        else
        {
            // No speed boost, revert to base speed
            speed = speed;
        }*/
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

            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rigidBody2d.MoveRotation(rotation);
        }
    }
    /*private void OnMove(InputValue inputvalue)
    {
        movementInput = inputvalue.Get<Vector2>();

    }*/

    /*public void ApplySpeedBoost(float boostAmount)
    {
        speed += boostAmount; // Increase player's speed by boost amount
        Debug.Log($"Speed boost applied! New speed: {speed}");
    }*/

}
