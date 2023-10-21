using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//Got this code from Naoise's class
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //This is a singleton, this same variable that can be called across all scripts

    [Header("Game States")] //public bools to determine if game is over
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
        if(Input.GetKeyDown(KeyCode.R)){ //If the player hits 'R' then restart the game (this key bind is temporary)
            RestartGame();
        }

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
    
}
