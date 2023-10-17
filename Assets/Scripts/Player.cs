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
    private InputActionReference movement, shoot, pointerPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if((horizontalInput > 0 && !facingRight) || (horizontalInput < 0 && facingRight)){
            Flip();
        }
    }

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
