using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private Vector2 direction;
    private AdvancedPlayerMovement player1;

    void Awake(){
        player1 = GetComponentInParent<AdvancedPlayerMovement>();
    }
    void FixedUpdate(){ 
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if(Input.GetKey(KeyCode.K) && player1.grounded){
            playerRigidbody = GetComponentInParent<Rigidbody2D>();
            playerRigidbody.AddForce(direction.normalized * -400f);
            //Debug.Log("POGO TOUCHED GROUND");
        }
    }
}
