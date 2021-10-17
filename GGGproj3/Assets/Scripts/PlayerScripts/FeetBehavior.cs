using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetBehavior : MonoBehaviour
{
    private int totalGround;

    // Start is called before the first frame update
    void Start()
    {
        totalGround = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullet collision");
        if (other.gameObject.tag == "Ground")
        {
            totalGround += 1;
            GetComponentInParent<PlayerMovement>().isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("bullet collision");
        if (other.gameObject.tag == "Ground")
        {
            totalGround -= 1;
            if (totalGround <= 0)
            {
                GetComponentInParent<PlayerMovement>().isGrounded = false;
            }
        }
    }
}
