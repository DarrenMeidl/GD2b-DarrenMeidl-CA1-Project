using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from this discussions page, link: https://discussions.unity.com/t/make-condition-for-opening-a-door-can-only-be-opened-when-a-lever-has-been-activated-before/130023/2
public class LeverController : MonoBehaviour
{
    public GameObject door;
    private bool leverRight;
    [SerializeField] private float leverRange = 1f;
    [SerializeField] private LayerMask playerLayers;
    // Start is called before the first frame update
    void Start()
    {
        leverRight = true; //Lever always defaults to facing right
    }
    
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, leverRange, playerLayers); //Gets list of colliders that fall in a circle (created at the lever's position, with a radius of 'leverRange', (only in the playerLayers layer specified in the inspector) & stores them in 'hitPlayers' 
            foreach (Collider2D player in hitPlayers){  //For every player 2d collider that is in the list of hitPlayers collider, it will carry out the code below
                PlayerHealth playerObj = player.GetComponent<PlayerHealth>(); //Grabs PlayerHealth component from other collider
                if (playerObj != null){ //If this isn't nothing, so IS an object with PlayerHealth script, activate lever
                    ActivateLever();
                    if(leverRight){ //if it's facing right, rotate left
                        gameObject.transform.Rotate(0, 0, 90);
                        leverRight = false; //Set leverRight to false
                    }
                    else {
                        gameObject.transform.Rotate(0, 0, -90); //Otherwise, rotate right
                        leverRight = true;
                    }
                }
            }
        }
    }

    void ActivateLever(){
        door.GetComponent<DoorController>().SetLeverOpenable(true);
    }

    /*public void OnTriggerEnter2D(Collider2D other){
        PlayerHealth player = other.GetComponent<PlayerHealth>(); //Grabs PlayerHealth component from other collider, if there is one
        if (player != null){ //If this isn't nothing, so IS an object with PlayerHealth script, activate lever
        ActivateLever();
        }
    }*/
}
