using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAxeBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float Damage;

    [SerializeField]
    [Tooltip("Time to return to player")]
    private float ArcTime;

    [SerializeField]
    [Tooltip("Gravity upon returning to player")]
    private float ArcGravity;

    public AxeHolderBehavior axeHolderBehavior;
    private Transform PlayerTransform;
    private Rigidbody2D rb;
    private bool returning = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullet collision");
        if (other.gameObject.tag == "Enemy" && !returning)
        {
            // Damage
            other.gameObject.GetComponent<EnemyMovement>().DecreaseEnemyHealth(Damage);

            // Calculate return tragectory
            PlayerTransform = axeHolderBehavior.gameObject.transform;
            float a = -9.8f * ArcGravity;
            float v_x = (PlayerTransform.position.x - transform.position.x) / ArcTime;
            float v_y = (PlayerTransform.position.y - transform.position.y - 0.5f * a * Mathf.Pow(ArcTime, 2)) / ArcTime;
            rb.velocity = new Vector2(v_x, v_y);
            rb.gravityScale = ArcGravity;

            // Returning logic
            returning = true;
            StartCoroutine(DurationDestroy());
        }
        else if (other.gameObject.tag == "Player" && returning)
        {
            axeHolderBehavior.RetrieveAxe();
            Destroy(transform.gameObject);
        }
    }

    private IEnumerator DurationDestroy()
    {
        yield return new WaitForSeconds(ArcTime * 3f);
        Destroy(transform.gameObject);
    }
}
