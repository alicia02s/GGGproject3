using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickedWeaveBehavior : MonoBehaviour
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

    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y + 2f), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
