using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider2D;
    private bool m_IsGrounded;
    private float subsequentJumpsRemaining;
    private float currentSpeedMultiplier = 1;
    private bool canDash = true;

    [SerializeField]
    [Tooltip("Player speed")]
    private float speed;

    [SerializeField]
    [Tooltip("Dash ability speed multiplier")]
    private float dashSpeed;

    [SerializeField]
    [Tooltip("Dash ability duration")]
    private float dashDuration;

    [SerializeField]
    [Tooltip("Dash ability cooldown")]
    private float dashCooldown;

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
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dash ability
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            StartCoroutine(DashCooldown());
        }

        // Horizontal movement
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = rb.velocity + new Vector2(-speed * currentSpeedMultiplier - rb.velocity.x, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = rb.velocity + new Vector2(speed * currentSpeedMultiplier - rb.velocity.x, 0);
        }
        else
        {
            rb.velocity = rb.velocity + new Vector2(-rb.velocity.x, 0);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump(jumpStrength);
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

    public void resetJumps()
    {
        subsequentJumpsRemaining = subsequentJumps;
    }

    private void Jump(float strength)
    {
        rb.velocity = rb.velocity + new Vector2(0, strength - rb.velocity.y);
    }

    private IEnumerator Dash()
    {
        currentSpeedMultiplier += dashSpeed;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(dashDuration);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        currentSpeedMultiplier -= dashSpeed;
    }

    private IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
