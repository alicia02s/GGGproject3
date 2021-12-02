using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempCustomizeTextDisplay : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        if (StaticVariableController.weaponChoice == null)
        {
            gameObject.GetComponent<Text>().text = "[ Primary Weapon ]\n\n" + "\t[ Pistol ]\n\n";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "[ Primary Weapon ]\n\n" + "\t[ " + StaticVariableController.weaponChoice.name + " ]\n\n";
        }
        if (StaticVariableController.secondaryWeaponChoice == null)
        {
            gameObject.GetComponent<Text>().text += "[ Secondary Weapon ]\n\n" + "\t[ Shotgun ]";
        }
        else
        {
            gameObject.GetComponent<Text>().text += "[ Secondary Weapon ]\n\n" + "\t[ " + StaticVariableController.secondaryWeaponChoice.name + " ]";
        }
    }
}
