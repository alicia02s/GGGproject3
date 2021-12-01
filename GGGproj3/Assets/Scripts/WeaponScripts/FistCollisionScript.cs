using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistCollisionScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float Damage;

    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float force;

    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float upwardForce;

    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float forceRadius;

    private WickedPortalBehavior portal;
    private Vector2 lookingDirection;

    // Update is called once per frame
    private void Awake()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        portal = GetComponentInParent<FistBehavior>().portal;
        lookingDirection = GetComponentInParent<FistBehavior>().lookingDirection;
        // Only collide if fist is out of portal
        if (isPast(other.gameObject.transform.position))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, forceRadius, upwardForce);
            }

            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyMovement>().DecreaseEnemyHealth(Damage);
            }
        }
    }

    bool isPast(Vector3 enemyPos)
    {
        Vector2 tailPosition = (enemyPos - portal.gameObject.transform.position).normalized;
        if (Vector2.Dot(tailPosition, lookingDirection) < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
