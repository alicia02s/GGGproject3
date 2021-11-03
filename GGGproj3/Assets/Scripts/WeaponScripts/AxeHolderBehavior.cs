using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHolderBehavior : MonoBehaviour
{
    private GameObject m_BulletPrefab;
    private float InitialVelocity;

    [SerializeField]
    [Tooltip("Maximum held axes")]
    private int MaxAxes;

    [SerializeField]
    [Tooltip("Time to retrieve a new axe")]
    private float RechargeDuration;

    private int currAxes;

    [SerializeField]
    [Tooltip("Spinning Axe Sprite (visual only)")]
    private GameObject AxeSprite;

    private GameObject mainHand = null;
    private GameObject offHand = null;

    // Start is called before the first frame update
    void Start()
    {
        WeaponInfo info = GetComponent<WeaponInfo>();
        info.actionFunction = Shoot;
        m_BulletPrefab = info.m_BulletPrefab;
        InitialVelocity = info.InitialVelocity;

        // Axe holding
        currAxes = MaxAxes;
        if (currAxes >= 1)
        {
            SpawnMainHand();
        }
        if (currAxes > 1)
        {
            SpawnOffHand();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
    }

    public void Shoot()
    {
        if (currAxes > 0)
        {
            // Axe behavior
            Vector2 lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
            GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = lookingDirection * InitialVelocity;
            bullet.GetComponent<SpinningAxeBehavior>().axeHolderBehavior = this;

            // Axe recharge logic
            currAxes--;
            StartCoroutine(StartRecharge());

            // Axe holding
            if (currAxes == 0 && mainHand != null)
            {
                Destroy(mainHand);
                mainHand = null;
            }
            else if (currAxes == 1 && offHand != null)
            {
                Destroy(offHand);
                offHand = null;
            }
        }
    }

    private IEnumerator StartRecharge()
    {
        yield return new WaitForSeconds(RechargeDuration);
        RechargeAxe();
    }

    public void RetrieveAxe()
    {
        StopCoroutine(StartRecharge());
        RechargeAxe();
    }

    private void RechargeAxe()
    {
        currAxes = Mathf.Min(currAxes + 1, MaxAxes);

        // Axe holding
        if (currAxes == 1)
        {
            SpawnMainHand();
        }
        else if (currAxes >= 1)
        {
            SpawnOffHand();
        }
    }

    private void SpawnMainHand()
    {
        if (mainHand == null)
        {
            mainHand = Instantiate(AxeSprite, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            mainHand.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
            mainHand.transform.parent = this.gameObject.transform;
        }
    }

    private void SpawnOffHand()
    {
        if (offHand == null)
        {
            offHand = Instantiate(AxeSprite, new Vector2(transform.position.x, transform.position.y + 0.5f), transform.rotation);
            offHand.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
            offHand.transform.parent = this.gameObject.transform;
        }
    }
}