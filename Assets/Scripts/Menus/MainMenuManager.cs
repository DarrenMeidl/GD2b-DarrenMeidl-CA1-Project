using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Code from Naoise's class
public class MainMenuManager : MonoBehaviour
{
    [Header("Scene Names")] //Fields for storing game & options scene names
    [SerializeField]
    private string gameSceneName = "Level";
    [SerializeField]
    private string optionsSceneName = "Options";
    public void StartGame() //Function that loads the game scene by calling the LoadScene() function by string not index
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions() //Function that opens the options scene by calling the LoadScene() function by string not index
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    public void QuitGame() //Function that closes the application
    {
        Application.Quit();
    }
}
