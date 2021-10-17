using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The weapon prefab held by the player")]
    private GameObject m_WeaponPrefab;

    private GameObject CurrentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWeapon = Instantiate(m_WeaponPrefab, new Vector2(transform.position.x, transform.position.y) , transform.rotation);
        CurrentWeapon.transform.parent = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
