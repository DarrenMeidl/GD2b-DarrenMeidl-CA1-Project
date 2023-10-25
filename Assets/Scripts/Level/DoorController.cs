using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool openable;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        openable = false;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(openable && Input.GetKeyDown(KeyCode.E) && isOpen == false){
            //Move door to open position
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            openable = false;
            isOpen = true;
        }
        else if(openable && Input.GetKeyDown(KeyCode.E) && isOpen){
            //Move door to close position
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            openable = false;
            isOpen = false;
        }
        
    }

    public void SetOpenable(bool set){
        openable = set;
    }
}
