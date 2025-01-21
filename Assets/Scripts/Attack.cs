using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    private Movement playerMovement;
    public Transform firePoint;
    public GameObject fireballPrefab;
    //private float timer = 1000f;//timer after every shot
    public float timeToWaitBeforeFire;//cooldown time/wait time between shots

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }//end start

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("fire");
        }

    }//end update


    public void Shoot()
    {
        //shooting

        //fire the shot
        Instantiate(fireballPrefab, firePoint.position, transform.rotation);
    }
}//end class
