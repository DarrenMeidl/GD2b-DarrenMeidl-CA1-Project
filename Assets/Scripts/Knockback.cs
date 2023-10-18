using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Vector2 moveDirection;
    public Rigidbody2D playerRigidbody;
    Vector2 direction;
    public Transform player;

    
    void Update(){
        //direction = player.position - transform.position;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            playerRigidbody = GetComponentInParent<Rigidbody2D>();
            /*moveDirection = playerRigidbody.transform.position - other.transform.position;
            //direction = playerRigidbody.position-transform.position;
            playerRigidbody.AddForce( direction.normalized * 500f);
            Debug.Log("POGO TOUCHED GROUND");*/
            playerRigidbody.AddForce(direction.normalized * -1200f);
            Debug.Log("POGO TOUCHED GROUND");
        }
    }
}
