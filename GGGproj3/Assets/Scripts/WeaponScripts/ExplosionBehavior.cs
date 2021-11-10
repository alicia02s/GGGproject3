using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
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
