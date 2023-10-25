using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayerOutOfBounds : MonoBehaviour
{
    private AdvancedPlayerMovement player;
    private GameOverMenu gameOverMenu;
    
    //Trigger function to test if this checkpoint is colliding with a player object
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject.GetComponent<AdvancedPlayerMovement>(); //Gets the AdvancedPlayerMovement script component from the passed in 'other' game object & assigns it to 'player' 
        if (player != null) //If the player isn't nothing, call the GameOver() function from BeatGameMenu object
        {
            gameOverMenu = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>();
            gameOverMenu.GameOver();
            Debug.Log("PLAYER COLLIDED WITH OUTSIDE BOUNDS POINT!"); //Testing purposes
        }
    }
}
