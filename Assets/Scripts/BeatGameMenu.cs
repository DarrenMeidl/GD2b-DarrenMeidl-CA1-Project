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
    
    //Game is beaten & BeatGameMenu will be shown
    public void EndGame(){
        isBeaten = true;
        beatGameMenu.SetActive(true);
        AudioManager.instance.PauseBackgroundMusic(); //Pause background music
        AudioManager.instance.PlayGameFinishedSound(); //Play victory sound
    }

    //This function loads the main menu scene, closes the beat game menu if it's still open & sets isBeaten to false
    public void LoadMainMenu()
    {
        AudioManager.instance.PlayBackgroundMusic(); //Resumes background music
        Time.timeScale = 1f;
        beatGameMenu.SetActive(false);
        isBeaten = false;
        SceneManager.LoadScene("Main Menu"); //Loads the scene by name
    }
}
