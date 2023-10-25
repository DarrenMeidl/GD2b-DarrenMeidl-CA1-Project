using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from this discussions page, link: https://discussions.unity.com/t/make-condition-for-opening-a-door-can-only-be-opened-when-a-lever-has-been-activated-before/130023/2
public class LeverController : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        //door = GameObject.Find("Door (1)");
    }

    void ActivateLever(){
        door.GetComponent<DoorController>().SetOpenable(true);
    }

    public void OnTriggerEnter2D(Collider2D other){
        PlayerHealth player = other.GetComponent<PlayerHealth>(); //Grabs PlayerHealth component from other collider, if there is one
        if (player != null){ //If this isn't nothing, so IS an object with PlayerHealth script, activate lever
        ActivateLever();
        }
        else{
            return;
        }
    }
}
