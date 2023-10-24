using System.Collections;
using UnityEngine;
//Got this code from Naoise's class
//Got timer code from tutorial, link: https://dennisse-pd.medium.com/how-to-create-a-cooldown-system-in-unity-4156f3a842ae
public class AudioManager : MonoBehaviour   //This will be a singleton, only 1 version exists & can't be destroyed
{
    public static AudioManager instance;    //Same exact variable (not copy) that can be called across all scripts
    //Audio clips for jumping, walking, attacking, & background music
    public AudioClip jumpSound;
    public AudioClip footstepSound;
    public AudioClip attackSound;
    public AudioClip enemyAttackSound;
    public AudioClip backgroundMusic;
    //Seperate audio source for sound effects & background music, this allows background music to continue playing without interruption while other sound effects are playing
    public AudioSource soundEffectSource;
    public AudioSource backgroundMusicSource;
    //Adjust volume for background music
    [SerializeField] private float volume = 1;

    [Header("Cooldowns")]
    //Walk Timer
    [SerializeField] private float cooldownA = 1f; //Delays the time between plays
    private float nextShotA = 1f; //Determines if audio manager can play clip again, we can tell if 1 second passed using this variable
    
    
    
    
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

        SetBackgroundMusicVolume(volume); //Sets the volume before the game starts
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
    //Plays the attackSound audio clip on the soundEffectSource audio source once
    public void PlayEnemyAttackSound(){
        soundEffectSource.PlayOneShot(enemyAttackSound);
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