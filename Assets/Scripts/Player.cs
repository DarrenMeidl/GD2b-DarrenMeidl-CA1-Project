using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float jumpHeight = 7f;
    public float dashSpeed = 20f;
    public float crouchHeight = .5f;

    public float groundCheckRadius = 0.2f;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool grounded;
    private bool canDoubleJump = false;
    private bool isDashing = false;
    private bool isCrouching = false;
    private bool facingRight = true;

    private PlayerMover playerMover;
    private Vector2 horizontalInput, pointerInput;
    public Vector2 PointerInput => pointerInput;

    private Rigidbody2D body;
    private Animator anim;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        //grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        pointerInput = GetPointerInput();

        horizontalInput = movement.action.ReadValue<Vector2>();
        GameObject a = Instantiate(playerMover);
        a.MovementInput = horizontalInput;
        //anim.SetBool("walk", horizontalInput !=0);

        /*if((horizontalInput > 0 && !facingRight) || (horizontalInput < 0 && facingRight)){
            Flip();
        }*/
    }

    /*private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }*/

    /*private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
        anim.SetTrigger("jump");
    }*/

    private Vector2 GetPointerInput(){
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
