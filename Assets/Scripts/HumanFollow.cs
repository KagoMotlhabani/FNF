using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HumanFollow : MonoBehaviour
{
    public float distance; //when out of this range, follow player, when within, don't
    public Transform player;
    public float speed;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    public bool followToggle;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            followToggle = true;//follow on
            Debug.Log("Follow On");
        }
        if (Input.GetKey(KeyCode.U))
        {
            followToggle = false;//follow off
            Debug.Log("Follow Off");
        }

        if ((Math.Abs(player.position.x - this.transform.position.x) > distance) && followToggle)
        {
            //flip human so that she's looking at the player
            if (player.position.x > this.transform.position.x)
            {
                //player is to the right of human
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (player.position.x < this.transform.position.x)
            {
                //player is to the left of the human
                transform.eulerAngles = new Vector3(0, -180, 0);
            }

            //if the human is more than a certain distance away from the dragon, follow to catch up
            MoveTowardsPlayer();
            rb.velocity = new Vector2(movementDirection.x * speed, rb.velocity.y);

        }
        else
        {
            //stop following
            rb.velocity = new Vector2(0, 0);
        }

        if (rb.velocity.magnitude <= 0.01f)
        {
            anim.SetBool("isRunning", false);

        }
        else
        {
            anim.SetBool("isRunning", true);
        }

    }//end fixed update

    void MoveTowardsPlayer()
    {
        movementDirection = new Vector2((player.position.x - this.transform.position.x), 0).normalized;

    }//end movetowardsplayer


}
