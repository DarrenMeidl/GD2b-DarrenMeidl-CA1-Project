using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Awake(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("BULLET TOUCHED SOMETHING");
    }
}
