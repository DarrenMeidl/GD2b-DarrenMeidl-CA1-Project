using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{
    private AdvancedPlayerMovement player;
    private BeatGameMenu beatGameMenu;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Trigger function to test if this checkpoint is colliding with a player object
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject.GetComponent<AdvancedPlayerMovement>(); //Gets the AdvancedPlayerMovement script component from the passed in 'other' game object & assigns it to 'player' 
        if (player != null) //If the player isn't nothing, call the EndGame() function from BeatGameMenu object
        {
            beatGameMenu = GameObject.FindGameObjectWithTag("BeatGame").GetComponent<BeatGameMenu>();
            beatGameMenu.EndGame();
            Debug.Log("PLAYER COLLIDED WITH FINISH CHECKPOINT!"); //Testing purposes
        }
    }
}
