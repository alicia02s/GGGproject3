using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float Damage;

    void Awake()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullet collision");
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMovement>().DecreaseEnemyHealth(Damage);
            Destroy(this.gameObject);

        }
        else if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
