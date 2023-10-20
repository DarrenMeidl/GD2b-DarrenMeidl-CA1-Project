using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//Code from Naoise's class

//Require components forces the script to only attach to a gameobject with the set components in this case a 2d rigidbody & animator
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AdvancedPlayerMovement : MonoBehaviour
{
    //Fields for Player movement values like speed & jump height underneath a header which appears in the inspector tab
    [Header("Player Settings")]
    public float speed = 10f;
    public float jumpHeight = 7f;
    //Fields for ground checking underneath a header which appears in the inspector tab
    [Header("Ground Check")]
    public float groundCheckRadius = 0.2f;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    
    //Fields for combat like attack range & damage underneath a header which appears in the inspector tab
    [Header("Attacking")]
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackRange = 1f; 

    public LayerMask enemyLayers;
    //Gets the player's rigidbody & animator components and sets them to the body & anim fields
    private Rigidbody2D body;
    private Animator anim;
    //private bools to check things like if Player is grounded, can double jump or if they are facing right
    private bool grounded;
    private bool facingRight = true;
    
    //Awake executes before the game starts
    private void Awake()
    {
        InitializeComponents(); //Calls the InitializeComponents() function
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();  //HandleInput() function is used in update as it makes controls & inputs more responsive in gameplay
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround); //Grounded bool is based around a 2d overlapcircle which is created on the position of the groundcheck object, radius set by groundCheckRadius float & only checks on the whatIsGround layer (set in player object in inspector)
    }
    //This function gets the Rigidbody2D & Animator components of this object
    private void InitializeComponents()
    {
        body = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }



    
    //this function calls all the other handleX() type functions, this is to make the code more readable & understable by grouping everything together
    private void HandleInput(){
        HandleJump();
        HandleAttack();
        HandleMovement();
    }
    //this function calls the attack() function only if the specified key is pressed
    private void HandleAttack(){
        if (Input.GetKeyDown(KeyCode.F)){
            Attack();
        }
    }
    //this function performs the walking movement for the player
    private void HandleMovement(){
        float horizontalInput = Input.GetAxisRaw("Horizontal"); //Gets the horizontal axis & stores in a field
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); //Adds velocity to the rigidbody by creating a new vector2 which multiplies horizontalInput float by the speed float but keeps the y velocity the same
        anim.SetBool("walk", horizontalInput !=0); //sets the walk bool in the animator to true or false based on whether the horizontalInput field is equal to 0 or not i.e. if player IS moving horizontally (input != 0) then "walk" bool is true thus playing walk animation

        /*if(horizontalInput != 0 && grounded){
            AudioManager.instance.PlayFootstepSound();
        }*/
        //If the player is moving right but they're not facing right OR if player is moving left but is facing right then call the Flip() function
        if((horizontalInput>0 && !facingRight) || (horizontalInput<0 && facingRight)){
            Flip();
        }
    }
    //If the player bool grounded is true & the space key is pressed, call the Jump() function
    private void HandleJump(){
        if(Input.GetKey(KeyCode.Space) && grounded){
            Jump();
        }
    }
    //This function flips the player sprite in the opposite direction
    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale; //Gets this object's current scale & stores in field
        currentScale.x *= -1;   //multiplies the field by -1
        gameObject.transform.localScale = currentScale; //Gets this object's current scale & sets it to whatever values the field is
        facingRight = !facingRight; //sets the bool to the opposite of itself to indicate if it's turned right or not
    }
    //Function that makes the player jump
    private void Jump(){ 
        body.velocity = new Vector2(body.velocity.x, jumpHeight); //Adds a new vector2 (keeps the current x position the same but adds 'jumpHeight' to the y velocity) to the current object's rigidbody velocity
        grounded = false; //Sets grounded to false, since player is in the air
        anim.SetTrigger("jump"); //plays the jump animation in the player's Animator
    }


    //This function deals the player's attack damage to any object that is considered an enemy
    void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers); //Gets list of colliders that fall in a circle (created at the player's position, with a radius of 'attackRange', only in the enemyLayers layer specified in the inspector) & stores them in 'hitEnemies' 
        foreach (Collider2D enemy in hitEnemies)    //For every enemy 2d collider that is in the list of hitEnemies collider, it will carry out the code below
        {
            //enemyController is assigned the Collider2D enemy's component: EnemyController 
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            //If the enemyController is not nothing, then it will call the TakeDamage() function from the EnemyController script & pass in the player's field attackDamage which is set above
            if (enemyController != null)
            {
                enemyController.TakeDamage(attackDamage);
                Debug.Log("Enemy Damaged!");    //Prints message in console, to test if enemy has been damaged
            }

        }
    }
    //Function that draws a gizmo in the scene view
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;   //Sets gizmo colour to red
        Gizmos.DrawWireSphere(transform.position, attackRange); //Draws a sphere at the player's current position with a radius of whatever 'attackRange' field is set to
    }

}