using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from unity tutorial, link: https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys
public class PogoStickController : MonoBehaviour
{
    public Transform bulletSpawnPoint; //Reference to bullet spawn point
    public GameObject bulletPrefab; //Reference to Bullet Prefab
    public GameObject bulletTeleporterPrefab; //Reference to TeleporterBullet Prefab
    //Called before game starts, sets the rotation of the pogo stick to be 90 degrees
    void Awake(){
        
    }
    
    void Update(){
        //If player presses the key specified, calls the Shoot() function
        if(Input.GetKeyDown(KeyCode.N)){
            Shoot();
        }
        //If player presses the key specified, calls the ShootTeleporter() function
        if(Input.GetKeyDown(KeyCode.M)){
            ShootTeleporter();
        }
    }

    public void Shoot(){
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Spawns clone of Bullet prefab at the bulletSpawnPoint transform position & rotation
    }

    public void ShootTeleporter(){
        Instantiate(bulletTeleporterPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Spawns clone of TeleporterBullet prefab at the bulletSpawnPoint transform position & rotation
    }


    /* OLD ROTATE BY MOUSE FUNCTION
    //Function that rotates PogoStick in direction of mouse, link: https://www.youtube.com/watch?v=nytgMFsaGMk&list=PL6e87e698K00dgUn3f6GoxrIoi7xeYYFk&index=8&t=193s&ab_channel=PekkeDev
    void Update(){
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Sets dir vector to the mouse position
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;    //Reurn value is the angle in radians between the x-axis & the Vector2, converts radians to degrees
        Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);    //Sets the object rotation around the axis, we add +90 so the end of PogoStick follows mouse not red arrow, 
        transform.rotation = rotation;  //Transforms the current rotation to whatever the next calculated rotation value is after each frame
    }*/
}
