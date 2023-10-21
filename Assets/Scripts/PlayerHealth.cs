using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Combat Settings")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private int attackDamage = 1;

    private GameOverMenu gom;
    // Awake is called before the game starts
    void Awake(){
        currentHealth = maxHealth; //Sets current health to full
        gom = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>(); //Finds GameOverMenu object through tag "GameOver"
    }

    void Update(){  //If player presses the 'I' key, it will call the TakeDamage() function
        if(Input.GetKeyDown(KeyCode.I)){
            TakeDamage(attackDamage);
        }
    }
    //Function that decreases the players's current health by whatever damage amount has been passed through & calls the GameOver() function if the current health has hit 0 or less than 0
    public void TakeDamage(int damageAmount){
        currentHealth -= damageAmount;
        Debug.Log("PLAYER TOOK DAMAGE"); //Test to see if player is taking damage or not
        if(currentHealth <= 0){
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
