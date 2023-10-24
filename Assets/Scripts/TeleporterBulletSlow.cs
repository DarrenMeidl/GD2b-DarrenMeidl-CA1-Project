using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from unity tutorial, link: https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys

//Require components forces the script to only attach to a gameobject with the set components in this case a 2d rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class TeleporterBulletSlow : MonoBehaviour
{
    //Fields for getting rigidbody of bullet & speed
    public float bulletSpeed = 5;
    public Rigidbody2D rb;
    //Public static fields
    public static Vector2 contactPointSlow;
    public static bool hasContactedSlow;
    public static int bulletCountSlow;
    void Start(){
        //Transforms the bullet's rigidbody by the opposite of the green axis multiplied by the bulletSpeed amount
        rb.velocity = (transform.up * -1) * bulletSpeed;
        hasContactedSlow = false; //Tells whether bullet has made contact with Ground or not
    }

    //When bullet hits another collider, execute code
    void OnCollisionEnter2D(Collision2D hitInfo){
        contactPointSlow = hitInfo.GetContact(0).point; //Get point of contact where this object collided with the other object
        hasContactedSlow = true; //has hit the Ground object
        bulletCountSlow = bulletCountSlow - 1; //Before destroying itself, this object will reduce the bullet count by 1 (which should equal to 0)
        Debug.Log("THIS IS: " + contactPointSlow); //Testing
        Debug.Log(hitInfo.GetContact(0).point); //Testing
        Destroy(gameObject); //Destroys bullet
    }
}
