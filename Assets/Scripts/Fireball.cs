using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    public bool hitSomething;
    public bool hitGem;
    public float lifeTime = 5f;
    //public GameObject gem;
    //private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(gameObject, lifeTime);

        /*
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        if (movement.horzDirection >= 0.1f)
        {
            rb.AddForce(Vector2.right * fireballSpeed, ForceMode2D.Impulse);
        }
        else if (movement.horzDirection <= -0.1)
        {
            rb.AddForce(Vector2.left * fireballSpeed, ForceMode2D.Impulse);
*/

    }

    // Update is called once per frame
    void Update()
    {
        if (hitSomething)
        {
            //destroy maybe?
            //Destroy(gameObject);
        }

        float force = Time.deltaTime * fireballSpeed;
        transform.Translate(force, 0, 0);

    }//end update

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Big Gem"))
        {
            //destroy the gem
            hitGem = true;
            Debug.Log(" you hit the big gem");
            //Destroy(gem);

        }
        
        hitSomething = true;//if it hits something, trigger the explosion animation
        Debug.Log("hit something");

        //play animation
    }
}
