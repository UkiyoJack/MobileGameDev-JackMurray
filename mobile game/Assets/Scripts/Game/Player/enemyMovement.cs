using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb;

    private awareness awarenessController;
    private Vector2 targetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        awarenessController = GetComponent<awareness>();
    }

     private void FixedUpdate()
    {
        updateTargetDir();
        rotate();
        velocity();
    }

    private void updateTargetDir()
    {
        if (awarenessController.aware)
        {
            targetDirection = awarenessController.playerDirection;

        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void rotate()
    {
        if (targetDirection == Vector2.zero)
        {
            return;                             
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection); //quaternion to rotare to target
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void velocity()
    {
        if(targetDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;

        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }
}
