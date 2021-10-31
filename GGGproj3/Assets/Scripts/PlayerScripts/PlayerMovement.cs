using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool m_IsGrounded;
    private float subsequentJumpsRemaining;

    [SerializeField]
    [Tooltip("Strength at which the player jumps")]
    private float jumpStrength;

    [SerializeField]
    [Tooltip("Strength at which the player jumps (for multiple jumps)")]
    private float subsequentJumpStrength;

    [SerializeField]
    [Tooltip("How many extra jumps the player gets")]
    private int subsequentJumps;

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
            if (isGrounded)
            {
                Jump(jumpStrength);
                subsequentJumpsRemaining = subsequentJumps;
            }
            else if (subsequentJumpsRemaining > 0)
            {
                Jump(subsequentJumpStrength);
                subsequentJumpsRemaining--;
            }
        }
    }

    public bool isGrounded {
        get { return m_IsGrounded; }
        set { m_IsGrounded = value; }
    }

    private void Jump(float strength)
    {
        rb.velocity = rb.velocity + new Vector2(0, strength - rb.velocity.y);
    }
}
