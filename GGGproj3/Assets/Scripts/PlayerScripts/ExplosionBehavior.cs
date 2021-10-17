using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float Damage;

    [SerializeField]
    [Tooltip("Bullet Duration")]
    private float Duration;

    void Awake()
    {
        StartCoroutine(DurationDestroy());
    }

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

    private IEnumerator DurationDestroy()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(transform.gameObject);
    }
}