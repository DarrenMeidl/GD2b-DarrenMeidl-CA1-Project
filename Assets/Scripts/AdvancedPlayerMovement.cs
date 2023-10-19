using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//Code from Naoise's class
public class AdvancedPlayerMovement : MonoBehaviour
{
    //Fields for Player movement values like speed & jump height
    public float speed = 10f;
    public float jumpHeight = 7f;
    //Fields for ground checking
    public float groundCheckRadius = 0.2f;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    //Rigidbody & Animator classes
    private Rigidbody2D body;
    private Animator anim;
    //bools to check things like if Player is grounded, can double jump or if they are facing right
    private bool grounded;
    private bool facingRight = true;
    //Fields for combat like attack range & damage
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackRange = 1f; 
    public LayerMask enemyLayers;
    //Gets the player's rigidbody & animator components and sets them to the body & anim fields
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        anim.SetBool("walk", horizontalInput !=0);

        if(Input.GetKeyDown(KeyCode.F)){
            Attack();
        }

        if((horizontalInput > 0 && !facingRight) || (horizontalInput < 0 && facingRight)){
            Flip();
        }
        
        if (Input.GetKey(KeyCode.Space) && grounded){
            Jump();
        }

        
    }

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
        anim.SetTrigger("jump");
    }
    //This function deals the player's attack damage to any object that is considered an enemy
    void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers); // ?
        foreach (Collider2D enemy in hitEnemies)    //For every enemy 2d collider that is in the hitEnemies collider, it will carry out the code below
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
    	
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;   //Sets gizmo colour to red which we can only see in the scene view
        Gizmos.DrawWireSphere(transform.position, attackRange); //Draws a sphere at the player's current position with a radius of whatever 'attackRange' is set to
    }

}