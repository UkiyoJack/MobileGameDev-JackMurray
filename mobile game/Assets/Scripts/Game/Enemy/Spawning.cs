using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject enemyPrefab; //assign spawned prefab of enemy
    public float spawnTimer = 5f; //delay between spawning of enemies
    public int enemyQuantity = 2; //amount of enemies spawned
    public float spawnRadius = 5.0f; //radius around spawner in world to spawn them
    void Start()
    {
        //begin spawning enemies using a coroutine
        StartCoroutine(SpawnEnemyWave());

    }

    IEnumerator SpawnEnemyWave()
    {
        while(true)
        {
            //spawn wave of enemies
            for (int i = 0; i < enemyQuantity; i++)
            {
                SpawnEnemies();
                yield return new WaitForSeconds(0.5f); //short delay between each enemy in the wave
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void SpawnEnemies()
    {
        //choose random pos arond spawner
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        //instantiate/spawn enemy at chosen position:
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
