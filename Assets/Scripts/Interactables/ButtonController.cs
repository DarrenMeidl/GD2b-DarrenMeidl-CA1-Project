using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from this discussions page, link: https://discussions.unity.com/t/make-condition-for-opening-a-door-can-only-be-opened-when-a-lever-has-been-activated-before/130023/2
public class ButtonController : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
    }

    public void OnTriggerEnter2D(Collider2D other){
        PlayerHealth playerObj = other.GetComponent<PlayerHealth>(); //Grabs PlayerHealth component from other collider
            if (playerObj != null){ //If this isn't nothing, so IS an object with PlayerHealth script, activate lever
                ActivateButton();
            }
    }
    void ActivateButton(){
        door.GetComponent<DoorController>().SetButtonOpenable(true);
    }
}
