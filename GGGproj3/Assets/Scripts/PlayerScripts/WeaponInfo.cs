using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet shot by this weapon")]
    public GameObject m_BulletPrefab;

    [SerializeField]
    [Tooltip("Initial velocity of bullet")]
    public float InitialVelocity;

    [SerializeField]
    [Tooltip("Cooldown in between shots")]
    public float m_ShootCooldown;

    public bool canShoot;
    public delegate void del();
    public del actionFunction;
    
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    public void Action()
    {
        if (canShoot)
        {
            actionFunction();
            if (m_ShootCooldown > 0)
            {
                canShoot = false;
                StartCoroutine(Cooldown());
            }
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(m_ShootCooldown);
        canShoot = true;
    }
}
