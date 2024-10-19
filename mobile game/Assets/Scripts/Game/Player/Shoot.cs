using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bubblePrefab;

    [SerializeField]
    private float bubbleSpeed;

    [SerializeField]
    private Transform shootOffset;

    [SerializeField]
    private float shootDelay;

    private bool shootContin;

    private float lastShotTime;

    // Update is called once per frame
    void Update()
    {
        if (shootContin)
        {
            float timeSinceShot = Time.time - lastShotTime;

            if (timeSinceShot >= shootDelay)
            {
                shootBubble();

                lastShotTime = Time.time;

            }
            
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(bubblePrefab.gameObject);
    }
    private void shootBubble()
    {
        Debug.Log("shoot!");
        GameObject bubble = Instantiate(bubblePrefab, shootOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bubble.GetComponent<Rigidbody2D>();

        rigidbody.velocity = bubbleSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        shootContin = inputValue.isPressed;

    }
}
