using System.Collections;
using UnityEngine;
//Got this code from Naoise's class
public class AudioManager : MonoBehaviour   //This will be a singleton, only 1 version exists & can't be destroyed
{
    public static AudioManager instance;    //Same exact variable (not copy) that can be called across all scripts
    //Audio clips for jumping, walking, attacking, & background music
    [Header("Player Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip footstepSound;
    public AudioClip attackSound;
    public AudioClip takeDamageSound;

    [Header("Enemy Audio Clips")]
    public AudioClip enemyAttackSound;
    public AudioClip enemyTakeDamageSound;

    [Header("Other Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip gameOverSound;
    public AudioClip beatGameSound;
    //Seperate audio source for player & enemy sound effects, player walking & background music, this allows background music to continue playing without interruption while other sound effects are playing
    [Header("Audio Sources")]
    public AudioSource playerSoundEffectSource;
    public AudioSource enemySoundEffectSource;
    public AudioSource walkSoundEffectSource;
    public AudioSource backgroundMusicSource;

    [Header("Volume Settings")]
    [SerializeField] private float volume = 1; //Adjust volume for background music
    [SerializeField] private float volume1 = 1; //Footstep volume
    [SerializeField] private float volume2 = 1; //Player sounds volume
    [SerializeField] private float volume3 = 1; //Enemy sounds volume

    
    
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
        //Adds audio source components to this game object
        enemySoundEffectSource = gameObject.AddComponent<AudioSource>(); //Sound effects for enemy
        playerSoundEffectSource = gameObject.AddComponent<AudioSource>(); //Sound effects for player
        walkSoundEffectSource = gameObject.AddComponent<AudioSource>(); //Sound effects
        backgroundMusicSource = gameObject.AddComponent<AudioSource>(); //Music

        backgroundMusicSource.clip = backgroundMusic; //Sets the backgroundMusicSource clip component to whatever the backgroundMusic audio clip is
        backgroundMusicSource.loop = true; //Loops the background music
        backgroundMusicSource.Play(); //Plays the backgroud music source
        
        //Sets the volumes before the game starts
        SetBackgroundMusicVolume(volume); 
        SetFootstepSoundVolume(volume1);
        SetPlayerSoundsVolume(volume2);
        SetEnemySoundsVolume(volume3);
    }



    //PLAYER SOUNDS
    //Plays the jumpSound audio clip on the playerSoundEffectSource audio source once
    public void PlayJumpSound(){
        playerSoundEffectSource.PlayOneShot(jumpSound);
    }
    //Plays the footstepSound audio clip on the walkSoundEffectSource audio source once
    public void PlayFootstepSound(){
        walkSoundEffectSource.PlayOneShot(footstepSound);

    }
    //Plays the attackSound audio clip on the playerSoundEffectSource audio source once
    public void PlayAttackSound(){
        playerSoundEffectSource.PlayOneShot(attackSound);
    }
    //Plays the takeDamageSound audio clip on the playerSoundEffectSource audio source once
    public void PlayTakeDamageSound(){
        playerSoundEffectSource.PlayOneShot(takeDamageSound);
    }


    




    //ENEMY SOUNDS
    //Plays the enemyAttackSound audio clip on the enemySoundEffectSource audio source once
    public void PlayEnemyAttackSound(){
        enemySoundEffectSource.PlayOneShot(enemyAttackSound);
    }
    //Plays the enemyTakeDamageSound audio clip on the enemySoundEffectSource audio source once
    public void PlayEnemyTakeDamageSound(){
        enemySoundEffectSource.PlayOneShot(enemyTakeDamageSound);
    }






    //OTHER SOUNDS
    //If the background music source isn't already playing, then call the Play() function on the background music source
    public void PlayBackgroundMusic(){
        if(!backgroundMusicSource.isPlaying){
            backgroundMusicSource.Play();
        }
    }
    //Play the gameOverSound audio clip on the playerSoundEffectSource audio source once
    public void PlayGameOverSound(){
        playerSoundEffectSource.PlayOneShot(gameOverSound);
    }
    //Play the beatGameSound audio clip on the playerSoundEffectSource audio source once
    public void PlayGameFinishedSound(){
        playerSoundEffectSource.PlayOneShot(beatGameSound);
    }



    





    //OTHER FUNCTIONS
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
    //Passes in a volume float, gets the walk sound effect source volume & sets it to the volume float
    public void SetFootstepSoundVolume(float volume1){
        walkSoundEffectSource.volume = volume1;
    }
    //Passes in a volume float, gets the walk sound effect source volume & sets it to the volume float
    public void SetPlayerSoundsVolume(float volume2){
        playerSoundEffectSource.volume = volume2;
    }
    //Passes in a volume float, gets the walk sound effect source volume & sets it to the volume float
    public void SetEnemySoundsVolume(float volume3){
        enemySoundEffectSource.volume = volume3;
    }
}