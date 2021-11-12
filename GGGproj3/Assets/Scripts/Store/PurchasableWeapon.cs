using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableWeapon : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Weapon being purchased.")]
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkWeapon();
    }

    void checkWeapon()
    {
        if (StaticVariableController.availableWeapons.Contains(weapon))
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
