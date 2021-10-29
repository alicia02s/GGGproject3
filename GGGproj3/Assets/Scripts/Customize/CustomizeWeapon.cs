using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChooseWeapon(GameObject weapon)
    {
        StaticVariableController.weaponChoice = weapon;

    }
}
