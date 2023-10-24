using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from unity tutorial, link: https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys
public class EnemyPSController : MonoBehaviour
{
    public Transform bulletSpawnPoint; //Reference to bullet spawn point
    public GameObject bulletPrefab; //Reference to Bullet Prefab
    [Header("Timer")]
    [SerializeField] private int cooldown = 2;
    private float timer;
    //Called before game starts, sets the rotation of the pogo stick to be 90 degrees
    void Awake(){
        
    }
    //Calls Shoot during FixedUpdate
    void FixedUpdate(){
        Shoot();
    }
    //Shoot is set up on a cooldown timer
    public void Shoot(){
        timer -= Time.deltaTime;
        if(timer > 0){
            return;   
        }
        timer = cooldown;
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Spawns clone of Bullet prefab at the bulletSpawnPoint transform position & rotation
        AudioManager.instance.PlayEnemyAttackSound();
    }
}
