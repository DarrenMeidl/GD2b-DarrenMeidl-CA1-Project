using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//Got this code from Naoise's class
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //This is a singleton, this same variable that can be called across all scripts

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

    }   
    
    
    
}
