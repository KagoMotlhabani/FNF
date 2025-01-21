using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed = 10f;
    public float jumpSpeed = 5f;
    public float horzDirection;//to check if facing left or right
    public float vertDirection;//to check if moving up or down
    public bool grounded;
    private float initialGravity;
    public float maxGlideSpeed;
    public Vector2 respawn;
    public GameObject fallBarrier;
    public bool outside = true;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        initialGravity = rb.gravityScale;
        respawn = transform.position;

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        horzDirection = Input.GetAxis("Horizontal"); //get the direction the player is facing
        vertDirection = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horzDirection * speed, rb.velocity.y); //move player in that direction

        //left-right direction flip
        if (horzDirection >= 0.1)
        {
            //facing right
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (horzDirection <= -0.1)
        {
            //facing left
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        //Jumping
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            grounded = false;
        }

        //gliding
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y < 0) //if holding space and moving down
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, -maxGlideSpeed);
            grounded = false;
        }
        else
        {
            rb.gravityScale = initialGravity;
        }

        //dashing
        if (Input.GetKey(KeyCode.RightShift) && grounded)
        {
            Debug.Log("Dashing");
        }//end

        //fallBarrier to move horizontally underneath player
        fallBarrier.transform.position = new Vector2(transform.position.x, fallBarrier.transform.position.y);

        //Animation controls
        if (rb.velocity.magnitude <= 0.01f)
        {
            anim.SetBool("isRunning", false);

        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (rb.velocity.y > 0.1f)
        {
            anim.SetTrigger("jumping");
        }
        else if (rb.velocity.y < -0.2f)
        {
            anim.SetTrigger("falling");
        }

    }//end update

    //Player on the ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

    }//end onCollisionEnter2D (grounded)

    //Player crossing triggers
    private void OnTriggerEnter2D(Collider2D col)
    {
        //player falling
        if (col.CompareTag("Fall Barrier"))
        {
            //respawn at last checkpoint
            transform.position = respawn;
        }
        else if (col.CompareTag("Checkpoint"))
        {
            respawn = transform.position;
        }

        //player in the cave;
        if (col.CompareTag("Cave"))
        {
            outside = false;
        }

    }//end on TriggerEnter

    void OnTriggerExit2D(Collider2D col)
    {
        //player leaves the cave;
        if (col.CompareTag("Cave"))
        {
            outside = true;
        }

    }

}//end class
