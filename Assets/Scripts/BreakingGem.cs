using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingGem : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("DESTROY THE GEM");
        }
    }
}
