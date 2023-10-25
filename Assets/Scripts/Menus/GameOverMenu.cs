using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Repurposed code from unity tutorial, link: https://www.youtube.com/watch?v=9dYDBomQpBQ&ab_channel=BMo
public class GameOverMenu : MonoBehaviour
{
    public GameObject gameoverMenu; //Used to reference GameOverMenu object
    public static bool isDead; //public bool to determines if player is dead or not
    // Awake is called before the game starts
    void Awake(){ //Player is not dead, time is set to normal & GameOverMenu object will be hidden before game starts
        isDead = false;
        Time.timeScale = 1f;
        gameoverMenu.SetActive(false);
    }
    //This function ends the game
    public void GameOver()
    {
        isDead=true; //Sets the game over bool to true
        gameoverMenu.SetActive(true); //Activates Death Screen
        Time.timeScale = 0f; //Stops time
        AudioManager.instance.PlayGameOverSound();
    }

    //This function restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Loads a scene by index, the index comes from the current active scene's index
    }

    //This function loads the main menu scene, closes the pause menu if it's still open & sets isPaused to false
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        gameoverMenu.SetActive(false);
        SceneManager.LoadScene("Main Menu"); //Loads the scene by name
        isDead = false;
    }

    
    
}

