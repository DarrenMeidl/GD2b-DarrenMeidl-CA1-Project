using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted code from different scripts from Naoise's class to put them in here
//Sorted original functions into groups of new functions for readability
public class PlayerHealth : MonoBehaviour
{
    //Fields for combat: attack range, damage & maximum attack damage underneath a header which appears in the inspector tab
    [Header("Combat Settings")]
    private int attackDamage;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int maxAttackDamage = 5;
    //HealthBar will access these fields
    [Header("Health Settings")]
    public static int playerMaxHealth = 3;
    public static int currentPlayerHealth; 

    public LayerMask enemyLayers; //Refence to a Layer, which will be set in the inspector
    private GameOverMenu gom; //private reference to a game object of type GameOverMenu

    // Awake is called before the game starts
    void Awake(){
        attackDamage = maxAttackDamage; //Sets current attack damage to full
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






    /*//this function calls the attack() function only if the specified key is pressed
    public void HandleAttack(){
        if (Input.GetKeyDown(KeyCode.F)){
            Debug.Log("YOU HIT F");
            Attack();
        }
    }*/

    /*//This function deals the player's attack damage to any object that is considered an enemy
    void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers); //Gets a collider that's within in a circle (created at the player's position, with a radius of 'attackRange', only in the layer specified in the inspector) & stores it in the 'hitEnemies' collider list
        foreach (Collider2D enemy in hitEnemies)    //For every 2d collider (called enemy) that is in the list of hitEnemies 2d colliders, it will carry out the code below
        {
            //enemyController is assigned the Collider2D enemy's component: EnemyController 
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            //If the enemyController is not nothing, then it will call the TakeDamage() function from the EnemyController script & pass in the player's field attackDamage which is set above
            if (enemyController != null) //If it does have EnemyController component
            {
                enemyController.TakeDamage(attackDamage); //Call takedamage() function to enemy
                AudioManager.instance.PlayAttackSound(); //calls the PlayAttackSound() function from the AudioManager script
                Debug.Log("Enemy Damaged!");    //Prints message in console, to test if enemy has been damaged
            }

        }
    }
    //Function that draws a gizmo in the scene view
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;   //Sets gizmo colour to red
        Gizmos.DrawWireSphere(transform.position, attackRange); //Draws a sphere at the player's current position with a radius of whatever 'attackRange' field is set to
    }*/
}
