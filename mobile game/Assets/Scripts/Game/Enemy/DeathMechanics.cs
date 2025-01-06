using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class DeathMechanics : MonoBehaviour
{
    public bool isAlive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAlive) //return early if already false
        {
            return;
        }

        if (collision.GetComponent<enemyMovement>()) //if has the enemy script (determines it as the enemy)
        {
            Debug.Log("Collided with: " + collision.gameObject.name);
            Debug.Log("yeah, you died.");
            isAlive = false; //if collides with object that has 'enemy movement script', set isAlive to flase (destroys gameobj)

            //HapticFeedback.HeavyFeedback(); //heavy haptic feedback on collision
            Destroy(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}










