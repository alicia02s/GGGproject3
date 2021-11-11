using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherBehavior : MonoBehaviour
{
    private GameObject m_BulletPrefab;

    private float InitialVelocity;

    // Start is called before the first frame update
    void Start()
    {
        WeaponInfo info = GetComponent<WeaponInfo>();
        info.actionFunction = Shoot;
        m_BulletPrefab = info.m_BulletPrefab;
        InitialVelocity = info.InitialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
    }

    public void Shoot()
    {
        Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = lookingDirection * InitialVelocity;
    }
}
