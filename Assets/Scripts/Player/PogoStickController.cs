using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from unity tutorial, link: https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys
//Cooldown timer code from tutorial, link: https://dennisse-pd.medium.com/how-to-create-a-cooldown-system-in-unity-4156f3a842ae
public class PogoStickController : MonoBehaviour
{
    public Transform bulletSpawnPoint; //Reference to bullet spawn point
    public GameObject bulletPrefab; //Reference to Bullet Prefab
    public GameObject bulletTeleporterPrefab; //Reference to TeleporterBullet Prefab
    public GameObject bulletTeleporterSlowPrefab; //Reference to TeleporterBullet Prefab

    [Header("Cooldown Timers")]
    //Teleporter Bullet
    [SerializeField] private float cooldownA = 1f; //Delays the time between shots
    private float nextShotA = 1f; //Determines if player can shoot again, we can tell if 1 second passed using this variable
    //Regular Bullet
    [SerializeField] private float cooldownB = 1f; //Delays the time between shots
    private float nextShotB = 1f; //Determines if player can shoot again, we can tell if 1 second passed using this variable
    //Slow Teleporter Bullet
    [SerializeField] private float cooldownC = 1f; //Delays the time between shots
    private float nextShotC = 1f; //Determines if player can shoot again, we can tell if 1 second passed using this variable
    
    void Start(){
        TeleporterBullet.bulletCount = 0;
        TeleporterBulletSlow.bulletCountSlow = 0;
    }
    void Update(){
        if(PauseMenu.isPaused == false && BeatGameMenu.isBeaten == false && GameOverMenu.isDead == false){
            HandleInput();  //HandleInput() function is used in update as it makes inputs more responsive. FixedUpdate is better for physics related code
        }
    }
    //Handles all HandleX() functions
    private void HandleInput(){
        HandleShoot();
        HandleShootTeleporter();
        HandleShootSlowTeleporter();
    }


    
    //Function handles Teleporting Bullet shooting
    private void HandleShootTeleporter(){
        //If player presses the key specified, there are no teleporter bullets & current time is greater than the current nextShot, call the ShootTeleporter() function
        if(Input.GetMouseButtonDown(2) && TeleporterBullet.bulletCount == 0 && Time.time > nextShotA){
            TeleporterBullet.bulletCount = TeleporterBullet.bulletCount + 1; //Adds 1 bullet to the teleporter bulletCount
            ShootTeleporter(); //Shoots teleporter bullet
            nextShotA = Time.time + cooldownA; //Next shot will become whatever the current time is but added with the cooldown variable
        }
    }
    //Function handles Regular Bullet shooting
    private void HandleShoot(){
        //If player presses the key specified, calls the Shoot() function
        if(Input.GetMouseButtonDown(0) && Time.time > nextShotB) {
            Shoot();
            nextShotB = Time.time + cooldownB;
        }
    }
    //Function handles Slow Teleporting Bullet shooting
    private void HandleShootSlowTeleporter(){
        //If player presses the key specified, there are no teleporter bullets & current time is greater than the current nextShot, call the ShootTeleporter() function
        if(Input.GetMouseButtonDown(1) && TeleporterBulletSlow.bulletCountSlow == 0 && Time.time > nextShotC){
            TeleporterBulletSlow.bulletCountSlow = TeleporterBulletSlow.bulletCountSlow + 1; //Adds 1 bullet to the teleporter bulletCount
            ShootSlowTeleporter(); //Shoots teleporter bullet
            nextShotC = Time.time + cooldownC; //Next shot will become whatever the current time is but added with the cooldown variable
        }
    }



    //Creates clone of whatever prefab bulletPrefab is set to in inspector
    private void Shoot(){
        AudioManager.instance.PlayAttackSound();
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Spawns clone of Bullet prefab at the bulletSpawnPoint transform position & rotation
    }
    //Creates clone of whatever prefab bulletTeleporterPrefab is set to in inspector
    private void ShootTeleporter(){
        AudioManager.instance.PlayAttackSound();
        Instantiate(bulletTeleporterPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Spawns clone of TeleporterBullet prefab at the bulletSpawnPoint transform position & rotation
    }
    //Creates clone of whatever prefab bulletTeleporterSlowPrefab is set to in inspector
    private void ShootSlowTeleporter(){
        AudioManager.instance.PlayAttackSound();
        Instantiate(bulletTeleporterSlowPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Spawns clone of TeleporterBullet prefab at the bulletSpawnPoint transform position & rotation
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
