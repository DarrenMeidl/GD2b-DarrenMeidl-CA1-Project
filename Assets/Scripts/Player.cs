using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 7f;
    public float dashSpeed = 20f;
    public float crouchHeight = .5f;
    public float groundCheckRadius = 0.2f;
    float horizontalInput;
    float pointerInput;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool canDoubleJump = false;
    private bool isDashing = false;
    private bool isCrouching = false;
    private bool facingRight = true;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        pointerInput = GetPointerInput();

        horizontalInput = movement.action.ReadValue<Vector2>();
        anim.SetBool("walk", horizontalInput !=0);

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

    private Vector2 GetPointerInput(){
        Vector3 mousPos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
