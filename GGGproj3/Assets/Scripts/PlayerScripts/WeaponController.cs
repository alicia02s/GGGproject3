using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Default weapon.")]
    private GameObject defaultWeapon;

    [SerializeField]
    [Tooltip("Default secondary weapon.")]
    private GameObject secondaryDefaultWeapon;

    // [SerializeField]
    // [Tooltip("The primary weapon prefab held by the player")]
    private GameObject m_PrimaryWeaponPrefab = StaticVariableController.weaponChoice;

    private GameObject m_SecondaryWeaponPrefab = StaticVariableController.secondaryWeaponChoice;

    private GameObject PrimaryWeapon;
    private GameObject SecondaryWeapon;

    // Start is called before the first frame update
    void Start()
    {
        if (m_PrimaryWeaponPrefab == null)
        {
            m_PrimaryWeaponPrefab = defaultWeapon;
        }
        PrimaryWeapon = Instantiate(m_PrimaryWeaponPrefab, new Vector2(transform.position.x, transform.position.y) , transform.rotation);
        PrimaryWeapon.transform.parent = this.gameObject.transform;
        PrimaryWeapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
        if (m_PrimaryWeaponPrefab == null)
        {
            m_SecondaryWeaponPrefab = secondaryDefaultWeapon;
        }
        SecondaryWeapon = Instantiate(m_SecondaryWeaponPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        SecondaryWeapon.transform.parent = this.gameObject.transform;
        SecondaryWeapon.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PrimaryWeapon.GetComponent<WeaponInfo>().Action();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SecondaryWeapon.GetComponent<WeaponInfo>().Action();
        }
    }
}
