using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//this code is from passivestar on YouTube

public class Trigger : MonoBehaviour
{
    //calling events
    public UnityEvent triggerEntered;
    public UnityEvent triggerExited;
    public string objectTag; //checking to see what object will trigger this event


    private void OnTriggerEnter2D(Collider2D other)
    {
        //when the player enters this zone, do something
        if (other.gameObject.CompareTag(objectTag))
        {
            triggerEntered.Invoke();
        }

    }//end onTriggerEnter

    private void OnTriggerExit2D(Collider2D other)
    {
        //when the player exits this zone, do something else
        if (other.gameObject.CompareTag(objectTag))
        {
            triggerExited.Invoke();
        }

    }//end onTriggerExit
}//end Trigger Class
