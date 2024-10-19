using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<enemyMovement>()) //if has the enemy script (determines as an ememy)
        {
            Debug.Log("collision!");
            Destroy(collision.gameObject);  //destroy enemy fish
            Destroy(gameObject);    //destroy bubble

            score.scoreCalculator();

        }
    }
}