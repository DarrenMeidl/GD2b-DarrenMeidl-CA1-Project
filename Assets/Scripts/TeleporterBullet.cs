using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from unity tutorial, link: https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys

//Require components forces the script to only attach to a gameobject with the set components in this case a 2d rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class TeleporterBullet : MonoBehaviour
{
    //Fields for getting rigidbody of bullet & speed
    public float bulletSpeed = 5;
    public int damage = 5;
    public Rigidbody2D rb;
    public static Vector2 contactPoint;
    void Start(){
        //Transforms the bullet's rigidbody by the opposite of the green axis multiplied by the bulletSpeed amount
        rb.velocity = (transform.up * -1) * bulletSpeed;
    }


    //When bullet hits another collider, execute code
    void OnCollisionEnter2D(Collision2D hitInfo){
        contactPoint = hitInfo.GetContact(0).point;
        Debug.Log("THIS IS: " + contactPoint);
        Debug.Log(hitInfo.GetContact(0).point);
        Destroy(gameObject);
    }
}
