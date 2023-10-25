using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Found code from unity tutorial, link: https://www.youtube.com/watch?v=9dYDBomQpBQ&ab_channel=BMo
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; //Used to reference PauseMenu object
    public static bool isPaused; //public bool to determines if game is paused or not
    // Awake is called before the game starts
    void Awake(){ //Game is not paused & PauseMenu will be hidden before game starts
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){ //If the player hits Escape & the game IS paused, then it resumes the game
            if(isPaused)
                ResumeGame();
            else    //Otherwise, call the pause function which pauses the game
                PauseGame();
        }
    }
    //This function pauses the game
    public void PauseGame(){ //Activates PauseMenu object, pauses time to 0 & sets pause bool to true
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        AudioManager.instance.PauseBackgroundMusic();
    }
    //This function resumes the game
    public void ResumeGame(){  //Deactivates PauseMenu object, sets time to normal speed & sets pause bool to false
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        AudioManager.instance.PlayBackgroundMusic();
    }

    //This function loads the main menu scene, closes the pause menu if it's still open & sets isPaused to false
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Main Menu"); //Loads the scene by name
        isPaused = false;
        AudioManager.instance.PlayBackgroundMusic();
    }
}
