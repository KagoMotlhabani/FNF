using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource src;
    public AudioClip ding;
    // Start is called before the first frame update
    void Start()
    {
        src.clip = ding;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            Debug.Log("Bloop");
            src.Play();
            Destroy(this.gameObject);
        }

    }//end on trigger enter


}
