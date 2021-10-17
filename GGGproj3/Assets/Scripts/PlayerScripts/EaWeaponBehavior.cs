using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaWeaponBehavior : MonoBehaviour
{
    private Vector2 dimensions;
    [SerializeField]
    [Tooltip("Explosion of this object")]
    private GameObject m_ExplosionPrefab;

    void Awake()
    {
        dimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= dimensions.x + 1 || Mathf.Abs(transform.position.y) >= dimensions.y + 1)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ground")
        {
            Instantiate(m_ExplosionPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
