using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShouldDisplay : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Basic Pistol")]
    private GameObject basicPistol;

    [SerializeField]
    [Tooltip("Basic Shotgun")]
    private GameObject basicShotgun;

    [SerializeField]
    [Tooltip("Basic Sniper")]
    private GameObject basicSniper;

    [SerializeField]
    [Tooltip("Spinning Axe")]
    private GameObject spinningAxe;

    [SerializeField]
    [Tooltip("Grenade Launcher")]
    private GameObject grenadeLauncher;

    [SerializeField]
    [Tooltip("Rocket Launcher")]
    private GameObject rocketLauncher;

    [SerializeField]
    [Tooltip("EA")]
    private GameObject EA;

    [SerializeField]
    [Tooltip("Wicked Weave")]
    private GameObject wickedWeave;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticVariableController.weaponChoice == null)
        {
            StaticVariableController.weaponChoice = basicPistol;
        }
        if (StaticVariableController.secondaryWeaponChoice == null)
        {
            StaticVariableController.secondaryWeaponChoice = basicShotgun;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Equals("EquipPrimaryWeapons"))
        {
            // Run a script
            checkPrimaryWeapons();
        } else if (gameObject.name.Equals("EquipSecondaryWeapons"))
        {
            // Run another script
            checkSecondaryWeapons();
        }
    }

    private void checkPrimaryWeapons()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Button childObject = gameObject.transform.GetChild(i).gameObject.GetComponent<Button>();
            if (childObject.name.Equals("BasicPistol")) {
                // Do something
                if (StaticVariableController.weaponChoice.Equals(basicPistol))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
            } else if (childObject.name.Equals("Shotgun"))
            {
                if (StaticVariableController.weaponChoice.Equals(basicShotgun))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            } else if (childObject.name.Equals("BasicSniper"))
            {
                if (!StaticVariableController.availableWeapons.Contains(basicSniper) || StaticVariableController.weaponChoice.Equals(basicSniper))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            } else if (childObject.name.Equals("Axe"))
            {
                if (!StaticVariableController.availableWeapons.Contains(spinningAxe) || StaticVariableController.weaponChoice.Equals(spinningAxe))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            } else if (childObject.name.Equals("Grenade"))
            {
                if (!StaticVariableController.availableWeapons.Contains(grenadeLauncher) || StaticVariableController.weaponChoice.Equals(grenadeLauncher))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            } else if (childObject.name.Equals("Rocket"))
            {
                if (!StaticVariableController.availableWeapons.Contains(rocketLauncher) || StaticVariableController.weaponChoice.Equals(rocketLauncher))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            } else if (childObject.name.Equals("EA"))
            {
                if (!StaticVariableController.availableWeapons.Contains(EA) || StaticVariableController.weaponChoice.Equals(EA))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                } else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                // Do something
            } else if (childObject.name.Equals("WickedWeave"))
            {
                if (!StaticVariableController.availableWeapons.Contains(wickedWeave) || StaticVariableController.weaponChoice.Equals(wickedWeave))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
            }
        }
    }

    private void checkSecondaryWeapons()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Button childObject = gameObject.transform.GetChild(i).gameObject.GetComponent<Button>();
            if (childObject.name.Equals("BasicPistol"))
            {
                // Do something
                if (StaticVariableController.secondaryWeaponChoice.Equals(basicPistol))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
            }
            else if (childObject.name.Equals("Shotgun"))
            {
                if (StaticVariableController.secondaryWeaponChoice.Equals(basicShotgun))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            }
            else if (childObject.name.Equals("BasicSniper"))
            {
                if (!StaticVariableController.availableWeapons.Contains(basicSniper) || StaticVariableController.secondaryWeaponChoice.Equals(basicSniper))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            }
            else if (childObject.name.Equals("Axe"))
            {
                if (!StaticVariableController.availableWeapons.Contains(spinningAxe) || StaticVariableController.secondaryWeaponChoice.Equals(spinningAxe))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            }
            else if (childObject.name.Equals("Grenade"))
            {
                if (!StaticVariableController.availableWeapons.Contains(grenadeLauncher) || StaticVariableController.secondaryWeaponChoice.Equals(grenadeLauncher))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            }
            else if (childObject.name.Equals("Rocket"))
            {
                if (!StaticVariableController.availableWeapons.Contains(rocketLauncher) || StaticVariableController.secondaryWeaponChoice.Equals(rocketLauncher))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
                // Do something
            }
            else if (childObject.name.Equals("EA"))
            {
                if (!StaticVariableController.availableWeapons.Contains(EA) || StaticVariableController.secondaryWeaponChoice.Equals(EA))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                // Do something
            }
            else if (childObject.name.Equals("WickedWeave"))
            {
                if (!StaticVariableController.availableWeapons.Contains(wickedWeave) || StaticVariableController.secondaryWeaponChoice.Equals(wickedWeave))
                {
                    childObject.enabled = false;
                    childObject.GetComponentInChildren<Text>().enabled = false;
                }
                else
                {
                    childObject.enabled = true;
                    childObject.GetComponentInChildren<Text>().enabled = true;
                }
            }
        }
    }
}
