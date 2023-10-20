using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I got all this code from Naoise's class
public class EnemyController : MonoBehaviour
{
    //Fields for movement, speed, checking distance from ground, whatIsGround layermask, 2 bools to see if Enemy is moving right & if it can change direction
    [Header("All Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float groundCheckDistance = 2f;
    [SerializeField] private LayerMask whatIsGround;
    private bool movingRight = true;
    private bool canChangeDirection = true;
    //Fields for combat, the enemy's max health & it's current health
    [Header("Combat Settings")]
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;

    //Adding fields for Rigidbody2D & EnemySpawner components
    private Rigidbody2D enemyRigidBody;
    private EnemySpawner spawner;

    //Getting 2D rigidbody component
    void Awake(){
        enemyRigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;  //Sets Enemy's health to the max health value before the game starts, essentially resetting the health back to full
    }
    //Passes in a reference to EnemySpawner, changes our 'spawner' into whatever the passed in 'spawnerReference' is
    public void Initialize(EnemySpawner spawnerReference)
    {
        spawner = spawnerReference;
    }

    //Calls the Move() function every physics frame per second
    void FixedUpdate()
    {
        Move();
    }
    //Function that controls Enemy movement
    void Move(){
        //This groundCheckPosition will have either one of the below vector2s depending on if the movingRight bool is true or false, it either adds or subtracts 0.2f to it's x position & keeps it's y value the same
        Vector2 groundCheckPosition = movingRight ?
            new Vector2(transform.position.x + 0.2f, transform.position.y):
            new Vector2(transform.position.x - 0.2f, transform.position.y);
        bool isGrounded = Physics2D.Raycast(groundCheckPosition, Vector2.down, groundCheckDistance, whatIsGround);
        //if Enemy isn't touching the ground & they can change direction, then their movingRight bool is reversed & the coroutine to delay the direction change occurs, this prevents them from falling off an edge
        if(!isGrounded && canChangeDirection){
            movingRight = !movingRight;
            StartCoroutine(DelayDirectionChange()); //Calls Coroutine function
        }
        //This changes the velocity of the Enemy's rigidbody, again based on whether it is going to move right or left
        enemyRigidBody.velocity = movingRight ?
            new Vector2(moveSpeed, enemyRigidBody.velocity.y):
            new Vector2(-moveSpeed, enemyRigidBody.velocity.y);
    }
    //Coroutine function sets bool false so Enemy can't change direction, then waits half a second & sets the bool to true
    IEnumerator DelayDirectionChange()
    {
        canChangeDirection = false;
        yield return new WaitForSeconds(0.5f);
        canChangeDirection = true;
    }
    //Function that decreases the enemy's current health by whatever damage amount has been passed through & calls the Die() function if the current health has hit 0 or less than 0
    public void TakeDamage(int damageAmount){
        currentHealth -= damageAmount;
        if(currentHealth <= 0){
            Die();
        }
    }
    //Function that will call the EnemyDied() function from EnemySpawner script to the spawner if it is not null. 
    public void Die(){
        if(spawner != null){
            spawner.EnemyDied();
        }
        Destroy(gameObject);    //It then destroys the enemy object
    }
    //Collision function to test if this enemy object is colliding with Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AdvancedPlayerMovement player = collision.gameObject.GetComponent<AdvancedPlayerMovement>(); //Gets the AdvancedPlayerMovement script component from the passed in 'collision' game object & assigns it to 'player' 
        if (player != null) //If the player isn't nothing, print the log message below into the console
        {
            Debug.Log("Player took damage from enemy!");
        }
    }
}