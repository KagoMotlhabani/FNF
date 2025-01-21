using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Vector2 movementDirection;
    public float speed = 5f;
    public float detectionRange = 5f;
    public float attackRange = 2.5f;
    public float distanceBetweenThem;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    /*
    Logic:
    If player is within range (so distance between them is smaller than the range)
       {move towards player}
    If player is within attack range (distance is smaller than that range)
       {attack player}


    */

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.position.x - this.transform.position.x) < detectionRange)
        {
            MoveTowardsPlayer();
            rb.velocity = new Vector2(movementDirection.x * speed, rb.velocity.y);

            if ((player.position.x - this.transform.position.x) < attackRange)
            {
                AttackPlayer();
                rb.velocity = new Vector2(movementDirection.x * 2 * speed, rb.velocity.y);

            }

        }//end if
        else
        {
            //wander i guess?
        }



    }//end fixedUpdate

    void MoveTowardsPlayer()
    {
        movementDirection = new Vector2((player.position.x - this.transform.position.x), 0).normalized;
    }

    void AttackPlayer()
    {
        Debug.Log("attacking player");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }


}//end class
