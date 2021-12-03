using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPistolInfo : MonoBehaviour
{
    private GameObject m_BulletPrefab;

    private float InitialVelocity;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        WeaponInfo info = GetComponent<WeaponInfo>();
        info.actionFunction = Shoot;
        m_BulletPrefab = info.m_BulletPrefab;
        InitialVelocity = info.InitialVelocity;
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
    	
        Vector2 lookingDirection = ((Vector2) player.position - (Vector2)transform.position).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
    }

    public void Shoot()
    {
        Vector2 lookingDirection = ((Vector2)player.position - (Vector2)transform.position).normalized;
        Debug.Log("instantiate bullet");
        GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = lookingDirection * InitialVelocity;
    }
}
