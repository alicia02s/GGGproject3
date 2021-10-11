using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = (Vector2)transform.position + new Vector2(-5, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = (Vector2)transform.position + new Vector2(5, 0) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = rb.velocity + new Vector2(0, 10 - rb.velocity.y);
        }
    }
}
