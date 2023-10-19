using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Vector2 moveDirection;
    public Rigidbody2D playerRigidbody;
    Vector2 direction;
    public Transform player;

    
    void FixedUpdate(){
        //direction = player.position - transform.position;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if(Input.GetKey(KeyCode.F)){
            playerRigidbody = GetComponentInParent<Rigidbody2D>();
            /*moveDirection = playerRigidbody.transform.position - other.transform.position;
            //direction = playerRigidbody.position-transform.position;
            playerRigidbody.AddForce( direction.normalized * 500f);
            Debug.Log("POGO TOUCHED GROUND");*/
            playerRigidbody.AddForce(direction.normalized * -400f);
            Debug.Log("POGO TOUCHED GROUND");
        }
    }
}
