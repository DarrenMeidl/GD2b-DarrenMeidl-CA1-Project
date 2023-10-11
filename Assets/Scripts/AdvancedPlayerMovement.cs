using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedPlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool facingRight = true;
    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded){
            Jump();
        }

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

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }
}
