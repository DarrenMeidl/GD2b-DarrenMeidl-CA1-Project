using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I got this code from Naoise's class
public class EnemySpawner : MonoBehaviour
{
    //Serialized fields for creating an Enemy, setting the spawn rate & spawn points
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private Transform[] spawnPoints;   //list of spawnPoint tranforms
    //Fields for storing the max number of enemies we can have & how many enemies are currently in the scene
    [Header("Limit Settings")]
    [SerializeField] private int maxEnemies = 5; 
    private int currentEnemies = 0; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Starts Invoking the SpawnEnemy() function after x seconds then repeats continously every x seconds (x being whatever spawnRate is set to)
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }

    void SpawnEnemy()
    {
        if(currentEnemies >= maxEnemies) return;    //Ensures that if the maxium number of enemies is reached or exceeded, it stops the function before it tries to execute the rest of the code below
        Transform spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)];  //Randomly picks 1 out of the list of spawnPoints to be the spawnPos transform
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity); // ?
        //Creates reference of type EnemyController & equals it to be the EnemyController component of the instantiated enemy
        EnemyController enemyController = spawnedEnemy.GetComponent<EnemyController>();
        enemyController.Initialize(this);   //Calls the Initialize() function (passing in this EnemySpawner) from our EnemyController script onto 'enemyController' which had just been set to the spawned enemy's EnemyController component script

        currentEnemies++;   //Increases the count of current enemies
    }

}
