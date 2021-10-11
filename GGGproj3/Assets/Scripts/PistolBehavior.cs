using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet shot by this weapon")]
    private GameObject m_BulletPrefab;

    [SerializeField]
    [Tooltip("Initial velocity of bullet")]
    private float InitialVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = lookingDirection * InitialVelocity;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
    }
}
