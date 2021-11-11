using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Explosion of this object")]
    private GameObject m_ExplosionPrefab;

    void Awake()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ground")
        {
            Instantiate(m_ExplosionPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            Destroy(transform.gameObject);
        }
    }
}
