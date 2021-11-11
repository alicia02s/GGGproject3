using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Explosion of this object")]
    private GameObject m_ExplosionPrefab;

    [SerializeField]
    [Tooltip("Bullet Duration")]
    private float Duration;

    void Awake()
    {
        StartCoroutine(DurationDestroy());
    }

    private IEnumerator DurationDestroy()
    {
        yield return new WaitForSeconds(Duration);
        Explode();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(m_ExplosionPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        Destroy(transform.gameObject);
    }
}
