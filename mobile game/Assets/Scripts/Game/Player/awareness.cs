using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awareness : MonoBehaviour
{
    public bool aware { get; private set; }

    public Vector2 playerDirection { get; private set; }


    [SerializeField]
    private float awareDistance;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;  //find any game object with 'player movement' and identify it as the player
    }

    void Update()
    {
        Vector2 playerChaser = player.position - transform.position;
        playerDirection = playerChaser.normalized;

        if (playerChaser.magnitude <= awareDistance)    //if enemy speed is less than the awareness distance threshold, set aware to true
        {
            aware = true;
        }
        else
        {
            aware = false;
        }
    }
}
