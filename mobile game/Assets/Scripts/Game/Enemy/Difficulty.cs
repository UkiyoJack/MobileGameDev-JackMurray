using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public Spawning spawningScript; //spawning script ref
    public float difficultyIncreaseRate = 10f; //time in sec, difficulty increase
    public float spawnIncreaseFactor = 1f; //increase  spawn count over time by this number
    public float speedIncreaseFactor = 0.1f; //increase speed over time by this number

    private float timeSinceDifficultyIncrease = 0f; //time since last difficulty++

    void Start()
    {
        // Initialize with the current settings
        timeSinceDifficultyIncrease = 0f;
    }

    void Update()
    {
        timeSinceDifficultyIncrease += Time.deltaTime;

        if (timeSinceDifficultyIncrease >= difficultyIncreaseRate)
        {
            //increase enemy quantity (ref to spawning script)
            spawningScript.enemyQuantity += Mathf.CeilToInt(spawnIncreaseFactor); //finds the NEXT highest int (rounds to nearest whole number)
            Debug.Log("quantity increased!");
            //increase the enemy speed for all enemies (if in scene)
            enemyMovement[] enemies = FindObjectsOfType<enemyMovement>();
            foreach (enemyMovement enemy in enemies) 
            {
                enemy.IncreaseSpeed(speedIncreaseFactor);
                Debug.Log("speed increased!"); //debugging purpose
            }

            timeSinceDifficultyIncrease = 0f; //reset timer
        }
    }
}
