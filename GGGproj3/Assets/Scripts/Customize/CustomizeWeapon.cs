using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChooseWeapon(GameObject weapon)
    {
        if (StaticVariableController.availableWeapons.Contains(weapon) || weapon.name.Equals("BasicPistol") || weapon.name.Equals("BasicShotgun"))
        {
            StaticVariableController.weaponChoice = weapon;
        } else
        {
            Debug.Log("Weapon not yet purchased.");
            // Change this so that it's reflect in the UI
        }
    }

    public void ChooseSecondaryWeapon(GameObject weapon)
    {
        if (StaticVariableController.availableWeapons.Contains(weapon) || weapon.name.Equals("BasicShotgun") || weapon.name.Equals("BasicPistol"))
        {
            StaticVariableController.secondaryWeaponChoice = weapon;
        } else
        {
            Debug.Log("Weapon not yet purchased.");
        }
    }
}
