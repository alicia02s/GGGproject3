using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickedPortalBehavior : MonoBehaviour
{
    private Vector2 lookingDirection;

    [SerializeField]
    [Tooltip("Bullet shot by this weapon")]
    private GameObject m_BulletPrefab;


    // Start is called before the first frame update
    void Awake()
    {
        lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
        GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        bullet.GetComponent<FistBehavior>().lookingDirection = lookingDirection;
        bullet.GetComponent<FistBehavior>().portal = this;
    }
}
