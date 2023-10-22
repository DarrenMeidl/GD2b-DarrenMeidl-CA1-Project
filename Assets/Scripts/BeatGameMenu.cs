using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Adapted code from unity tutorial, link: https://www.youtube.com/watch?v=9dYDBomQpBQ&ab_channel=BMo
public class BeatGameMenu : MonoBehaviour
{
    public GameObject beatGameMenu; //Used to reference beatGameMenu object
    public static bool isBeaten; //public bool to determines if game is beaten or not
    // Awake is called before the game starts
    void Awake(){ //Game is not beaten & BeatGameMenu will be hidden before game starts
        isBeaten = false;
        beatGameMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){ //If player hits E key, sets beatGameMenu to true (testing purposes)
            beatGameMenu.SetActive(true);
        }
    }
    
    //Game is beaten & BeatGameMenu will be shown
    public void EndGame(){
        isBeaten = true;
        beatGameMenu.SetActive(true);
    }
    //This function restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Loads a scene by index, the index comes from the current active scene's index
    }

    //This function loads the main menu scene, closes the beat game menu if it's still open & sets isBeaten to false
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        beatGameMenu.SetActive(false);
        isBeaten = false;
        SceneManager.LoadScene("Main Menu"); //Loads the scene by name
    }
}
