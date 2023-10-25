using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted code from different scripts from Naoise's class to put them in here
//Sorted original functions into groups of new functions for readability
public class PlayerHealth : MonoBehaviour
{
    //HealthBar will access these fields
    [Header("Health Settings")]
    public static int playerMaxHealth = 3;
    public static int currentPlayerHealth; 

    public LayerMask enemyLayers; //Refence to a Layer, which will be set in the inspector
    private GameOverMenu gom; //private reference to a game object of type GameOverMenu

    // Awake is called before the game starts
    void Awake(){
        currentPlayerHealth = playerMaxHealth; //Sets current health to full
        gom = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>(); //Finds GameOverMenu object through tag "GameOver" & sets it to 'gom' reference
    }

    //Function that decreases the players's current health by whatever damage amount has been passed through & calls the GameOver() function if the current health has hit 0 or less than 0
    public void TakeDamage(int damageAmount){
        AudioManager.instance.PlayTakeDamageSound();
        currentPlayerHealth -= damageAmount;
        Debug.Log("PLAYER TOOK DAMAGE"); //Test to see if player is taking damage or not
        if(currentPlayerHealth <= 0){
            gom.GameOver(); //Calls this function from the GameOverMenu script
        }
    }


    //Collision function to test if this player object is colliding with an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>(); //Gets the EnemyController script component from the passed in 'collision' game object & assigns it to 'enemy' 
        if (enemy != null) //If the enemy isn't nothing, print the log message below into the console
        {
            Debug.Log("Player collided with enemy!");

        }
    }
}
