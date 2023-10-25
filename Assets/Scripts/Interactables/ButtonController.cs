using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from this discussions page, link: https://discussions.unity.com/t/make-condition-for-opening-a-door-can-only-be-opened-when-a-lever-has-been-activated-before/130023/2
public class ButtonController : MonoBehaviour
{
    public GameObject door;
    [SerializeField] private float buttonRange = 1f;
    [SerializeField] private LayerMask playerLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        /*Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, buttonRange, playerLayers); //Gets list of colliders that fall in a circle (created at the lever's position, with a radius of 'leverRange', (only in the playerLayers layer specified in the inspector) & stores them in 'hitPlayers' 
        foreach (Collider2D player in hitPlayers){  //For every player 2d collider that is in the list of hitPlayers collider, it will carry out the code below
            PlayerHealth playerObj = player.GetComponent<PlayerHealth>(); //Grabs PlayerHealth component from other collider
            if (playerObj != null){ //If this isn't nothing, so IS an object with PlayerHealth script, activate lever
                ActivateButton();
            }
        }*/
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
