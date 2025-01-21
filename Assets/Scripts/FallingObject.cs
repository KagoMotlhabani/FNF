using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{

    public float detectionRange = 5f;
    public Transform player;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fireball"))
        {
            //drop the cage
            Debug.Log("Drop the CAGE!");
            rb.gravityScale = 1f;
        }
    }//end trigger enter

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Fireball"))
        {
            rb.gravityScale = 1f;
        }
    }
}
