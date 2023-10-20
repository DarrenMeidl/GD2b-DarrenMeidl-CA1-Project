using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//Got this code from Naoise's class
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //This is a singleton, this same variable that can be called across all scripts

    [Header("Game States")] //public bools to determine if game is paused or over
    public bool isPaused;
    public bool isGameOver;
    // Awake is called before the game starts
    void Awake()
    {
        //If the instance is nothing, then the instance will become this object & won't destroy when the scene loads
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{   //Otherwise, destroy this game object & end the function
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){ //If the player hits Escape & the game IS paused, it calls the resume function
            if(isPaused)
                ResumeGame();
            else    //Otherwise, call the pause function which pauses the game
                PauseGame();
        }
        if(Input.GetKeyDown(KeyCode.R)){ //If the player hits 'R' then restart the game (this key bind is temporary)
            RestartGame();
        }
        if(Input.GetKeyDown(KeyCode.L)){ //If the player hits 'L' then load the main menu scene (this key bind is temporary)
            LoadMainMenu();
        }

    }   
    
    //This function pauses the game
    public void PauseGame() //Sets pause bool to true & slows down time to half speed
    {
        isPaused = true;
        Time.timeScale = 0.5f;
        //this is where I'll put the pause menu 
    }
    //This function resumes the game
    public void ResumeGame() //Sets the pause bool to false & puts the time back to normal real time speed
    {
        isPaused = false; 
        Time.timeScale = 1f; 
        //this is where I'll turn off the pause menu 
    }
    //This function ends the game
    public void GameOver()
    {
        isGameOver=true; //Sets the game over bool to true
        //This is where I'll put in code for when the game ends
    }
    //This function restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Loads a scene by index, the index comes from the current active scene index
    }
    //This function loads the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); //Loads the scene by name
    }
}
