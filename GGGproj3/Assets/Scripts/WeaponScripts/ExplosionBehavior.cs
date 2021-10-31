using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
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
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMovement>().DecreaseEnemyHealth(Damage);
        }
    }
}
