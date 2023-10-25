using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from unity tutorial, link: https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys

//Require components forces the script to only attach to a gameobject with the set components in this case a 2d rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    //Fields for getting rigidbody of bullet & speed
    public float bulletSpeed = 5;
    public int damage = 1;
    public Rigidbody2D rb;

    void Start(){
        //Transforms the bullet's rigidbody by the opposite of the green axis multiplied by the bulletSpeed amount
        rb.velocity = (transform.up * -1) * bulletSpeed;
    }
    //Bullet velocity set in fixedupdate so that whenever the game is paused, finished or player died, bullets will freeze
    void FixedUpdate(){
        if(PauseMenu.isPaused == false && BeatGameMenu.isBeaten == false && GameOverMenu.isDead == false){
            rb.velocity = (transform.up * -1) * bulletSpeed;
        }
        else{
            rb.velocity = Vector3.zero;
        }
    }


    //When bullet hits another collider, execute code. I added extra functionality by also checking for a player object, so I can reuse this bullet prefab for the enemy turret
    void OnTriggerEnter2D(Collider2D hitInfo){
        EnemyController enemy = hitInfo.GetComponent<EnemyController>(); //Grabs EnemyController component from other collider, if there is one
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>(); //Grabs PlayerHealth component from other collider, if there is one
        if (enemy != null){ //If this isn't nothing, so IS an object with EnemyController script, make it take damage
            enemy.TakeDamage(damage);
        }
        else if (player != null){ //If this isn't nothing, so IS an object with PlayerHealth script, make it take damage
            player.TakeDamage(damage);
        }
        Debug.Log(hitInfo.name); //Testing purposes, Prints name of object hit
        Destroy(gameObject);
    }
}
