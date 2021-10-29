using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempCustomizeTextDisplay : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Current Weapon: " + StaticVariableController.weaponChoice.name;
    }
}
