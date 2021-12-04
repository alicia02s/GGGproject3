using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBehavior : MonoBehaviour
{
    private GameObject m_BulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        WeaponInfo info = GetComponent<WeaponInfo>();
        info.actionFunction = Shoot;
        m_BulletPrefab = info.m_BulletPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        float z = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;
        if (z < 0)
        {
            z += 360;
        }
        float x = 0;
        if (z > 90 && z < 270)
        {
            x = 180;
            z = 360 - z;
        }
        transform.rotation = Quaternion.Euler(new Vector3(x, 0, z));
    }

    public void Shoot()
    {
        Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        float z = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
    }

}
