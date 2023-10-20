using System.Collections;
using UnityEngine;
//Got this code from Naoise's class
public class AudioManager : MonoBehaviour   //This will be a singleton, only 1 version exists & can't be destroyed
{
    public static AudioManager instance;    //Same exact variable (not copy) that can be called across all scripts
    //Audio clips for jumping, walking, attacking, & background music
    public AudioClip jumpSound;
    public AudioClip footstepSound;
    public AudioClip attackSound;
    public AudioClip backgroundMusic;
    //Seperate audio source for sound effects & background music, this allows background music to continue playing without interruption while other sound effects are playing
    public AudioSource soundEffectSource;
    public AudioSource backgroundMusicSource;
    //Awake executes before the game starts
    void Awake(){
        //If the instance is nothing, then the instance will become this object & won't destroy when the scene loads
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{   //Otherwise, destroy this game object & end the function
            Destroy(gameObject);
            return;
        }
        //Adds two audio source components to this game object
        soundEffectSource = gameObject.AddComponent<AudioSource>(); //Sound effects
        backgroundMusicSource = gameObject.AddComponent<AudioSource>(); //Music

        backgroundMusicSource.clip = backgroundMusic; //Sets the backgroundMusicSource clip component to whatever the backgroundMusic audio clip is
        backgroundMusicSource.loop = true; //Loops the background music
        backgroundMusicSource.Play(); //Plays the backgroud music source
    }
    //Plays the jumpSound audio clip on the soundEffectSource audio source once
    public void PlayJumpSound(){
        soundEffectSource.PlayOneShot(jumpSound);
    }
    //Plays the footstepSound audio clip on the soundEffectSource audio source once
    public void PlayFootstepSound(){
        soundEffectSource.PlayOneShot(footstepSound);
    }
    //Plays the attackSound audio clip on the soundEffectSource audio source once
    public void PlayAttackSound(){
        soundEffectSource.PlayOneShot(attackSound);
    }
    //If the background music source isn't playing, then call the Play() function on the background music source
    public void PlayBackgroundMusic(){
        if(!backgroundMusicSource.isPlaying){
            backgroundMusicSource.Play();
        }
    }
    //Pauses the background music source
    public void PauseBackgroundMusic(){
        backgroundMusicSource.Pause();
    }
    //Stops the background music source
    public void StopBackgroundMusic(){
        backgroundMusicSource.Stop();
    }
    //Passes in a volume float, gets the background music source volume & sets it to the volume float
    public void SetBackgroundMusicVolume(float volume){
        backgroundMusicSource.volume = volume;
    }
}