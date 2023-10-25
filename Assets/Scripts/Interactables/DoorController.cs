using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from discussions page, link: https://discussions.unity.com/t/make-condition-for-opening-a-door-can-only-be-opened-when-a-lever-has-been-activated-before/130023/2
public class DoorController : MonoBehaviour
{
    private bool leverOpenable;
    private bool buttonOpenable;
    private bool isOpen;

    [Header("Timer")]
    [SerializeField] private float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        leverOpenable = false;
        buttonOpenable = false;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ACTIVATED BY LEVER
        if(leverOpenable && Input.GetKeyDown(KeyCode.E) && isOpen == false){
            //Move door to open position
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            leverOpenable = false;
            isOpen = true;
        }
        else if(leverOpenable && Input.GetKeyDown(KeyCode.E) && isOpen){
            //Move door to close position
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            leverOpenable = false;
            isOpen = false;
        }

        //ACTIVATED BY BUTTON
        if(buttonOpenable){
            //Move door to open position
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            //Timer, wait X seconds
            StartCoroutine(WaitThenClose());
            buttonOpenable = false; //Door cannot open again unless told otherwise
        }
    }

    public void SetLeverOpenable(bool set){
        leverOpenable = set;
    }
    public void SetButtonOpenable(bool set){
        buttonOpenable = set;
    }

    IEnumerator WaitThenClose(){
        //Wait X Seconds
        yield return new WaitForSeconds(waitTime);
        //Move door to close position
        transform.position = new Vector2(transform.position.x, transform.position.y + 2);
    }
}
