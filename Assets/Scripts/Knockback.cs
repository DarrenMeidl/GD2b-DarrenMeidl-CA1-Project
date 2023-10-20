using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private Vector2 direction;
    public Transform player;

    
    void FixedUpdate(){
        //direction = player.position - transform.position;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if(Input.GetKey(KeyCode.R)){
            playerRigidbody = GetComponentInParent<Rigidbody2D>();
            playerRigidbody.AddForce(direction.normalized * -400f);
            //Debug.Log("POGO TOUCHED GROUND");
        }
    }
}
