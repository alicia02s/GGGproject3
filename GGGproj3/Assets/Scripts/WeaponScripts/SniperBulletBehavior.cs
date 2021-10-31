using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBulletBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float Damage;

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullet collision");
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMovement>().DecreaseEnemyHealth(Damage);
        }
    }
}
