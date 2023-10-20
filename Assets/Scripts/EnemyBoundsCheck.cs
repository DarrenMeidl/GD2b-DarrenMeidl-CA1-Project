using UnityEngine;
//Code from Naoise's class
public class EnemyBoundsCheck : MonoBehaviour
{
    [Header("Fall Check")]
    [SerializeField] private float minY = -10f;  //This is the minimum y position at which the enemy is considered off the map
    
    [Header("Off Screen Check")]
    [Tooltip("Extra space before enemy is considered off screen")]
    [SerializeField] private float screenBuffer = 1.0f;
    //Gets a Camera & EnemyController
    private Camera mainCamera;
    private EnemyController enemyController;
    //Called before the game starts
    private void Awake()
    {
        mainCamera = Camera.main; //Sets Camera to be the Main Camera
        enemyController = GetComponent<EnemyController>(); //Sets the Enemy Controller to be the EnemyController component in this object

        if(!enemyController) //Prints an error message incase there is no EnemyController
        {
            Debug.LogError("EnemyBoundsCheck is missing EnemyController on the same GameObject!", gameObject);
        }
    }

    private void Update()
    {
        // Check if enemy has fallen off the main level
        if (transform.position.y < minY)
        {
            enemyController.Die(); //if it has, then it kills the Enemy
            return;
        }

        //Checks if the enemy has moved off the screen
        Vector3 enemyScreenPos = mainCamera.WorldToViewportPoint(transform.position); //Finds the transform point of the enemy, storing it in a vecotr
        if (enemyScreenPos.x < -screenBuffer || enemyScreenPos.x > 1 + screenBuffer || 
            enemyScreenPos.y < -screenBuffer || enemyScreenPos.y > 1 + screenBuffer) //If the enemy is outside the screen buffer, then it kills the Enemy
        {
            enemyController.Die();
        }
    }
}
