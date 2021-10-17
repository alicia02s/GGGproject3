using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet shot by this weapon")]
    private GameObject m_BulletPrefab;

    [SerializeField]
    [Tooltip("Initial velocity of bullet")]
    private float InitialVelocity;

    [SerializeField]
    [Tooltip("Cooldown in between shots")]
    private float m_ShootCooldown;

    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = lookingDirection * InitialVelocity;
            bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2Extension.Rotate(lookingDirection, 10f) * InitialVelocity;
            bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2Extension.Rotate(lookingDirection, 20f) * InitialVelocity;
            bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2Extension.Rotate(lookingDirection, -10f) * InitialVelocity;
            bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2Extension.Rotate(lookingDirection, -20f) * InitialVelocity;
            canShoot = false;
            StartCoroutine(Cooldown());
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(m_ShootCooldown);
        canShoot = true;
    }
}