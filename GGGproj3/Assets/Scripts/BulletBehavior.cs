using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Vector2 dimensions;
    [SerializeField]
    [Tooltip("Bullet Damage")]
    private float Damage;

    void Awake()
    {
        dimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= dimensions.x + 1 || Mathf.Abs(transform.position.y) >= dimensions.y + 1)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /* if (other.gameObject.tag == "Enemy")
        {
            other.TakeDamage(Damage);
            Destroy(this.gameObject);

        } */
    }
}
