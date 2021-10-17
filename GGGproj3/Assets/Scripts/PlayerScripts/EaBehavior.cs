using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Object spawned by this weapon")]
    private GameObject m_SpawnPrefab;

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            GameObject bullet = Instantiate(m_SpawnPrefab, new Vector2(transform.position.x, transform.position.y + 2.5f), Quaternion.Euler(new Vector3(0, 0, 0)));
            canShoot = false;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(m_ShootCooldown);
        canShoot = true;
    }
}
