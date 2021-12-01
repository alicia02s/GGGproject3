using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purchases : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How much the double jump costs.")]
    private int doubleJumpCost;

    [SerializeField]
    [Tooltip("How much the dash ability costs.")]
    private int dashCost;

    [SerializeField]
    [Tooltip("How much the armor upgrade costs.")]
    private int armorCost;

    [SerializeField]
    [Tooltip("How much the sniper costs.")]
    private int sniperCost;

    [SerializeField]
    [Tooltip("How much the axe costs.")]
    private int axeCost;

    [SerializeField]
    [Tooltip("How much the grenade costs.")]
    private int grenadeCost;

    [SerializeField]
    [Tooltip("How much the rocket costs.")]
    private int rocketCost;

    [SerializeField]
    [Tooltip("How much the EA costs.")]
    private int EACost;

    [SerializeField]
    [Tooltip("The Text object where the error message should be displayed.")]
    private Text thisText;

    private void Start()
    {
        thisText.enabled = false;
    }

    public void buyWeapon(GameObject weapon)
    {
        // Block out the button so you can't buy this weapon again
        if (weapon.name.Equals("BasicSniper"))
        {
            if (StaticVariableController.coinCount - sniperCost < 0)
            {
                StartCoroutine(showErrorMessage("You don't have enough coins to buy the sniper gun.", 2));
            }
            else
            {
                StaticVariableController.coinCount -= sniperCost;
                        StaticVariableController.availableWeapons.Add(weapon);

            }
        } else if (weapon.name.Equals("AxeHolder"))
        {
            if (StaticVariableController.coinCount - axeCost < 0)
            {
                StartCoroutine(showErrorMessage("You don't have enough coins to buy the spinning axe.", 2));
            }
            else
            {
                StaticVariableController.coinCount -= axeCost;
                StaticVariableController.availableWeapons.Add(weapon);

            }
        } else if (weapon.name.Equals("GrenadeLauncher"))
        {
            if (StaticVariableController.coinCount - grenadeCost < 0)
            {
                StartCoroutine(showErrorMessage("You don't have enough coins to buy the grenade launcher.", 2));
            }
            else 
            {
                StaticVariableController.coinCount -= grenadeCost;
                        StaticVariableController.availableWeapons.Add(weapon);

            }
        } else if (weapon.name.Equals("RocketLauncher"))
        {
            if (StaticVariableController.coinCount - rocketCost < 0)
            {
                StartCoroutine(showErrorMessage("You don't have enough coins to buy the rocket launcher.", 2));
            }
            else
            {
                StaticVariableController.coinCount -= rocketCost;
                        StaticVariableController.availableWeapons.Add(weapon);

            }
        } else if (weapon.name.Equals("Ea"))
        {
            if (StaticVariableController.coinCount - EACost < 0)
            {
                StartCoroutine(showErrorMessage("You don't have enough coins to buy the EA.", 2));
            }
            else
            {
                StaticVariableController.coinCount -= EACost;
                        StaticVariableController.availableWeapons.Add(weapon);

            }
        }
    }

    public void getDoubleJump()
    {
        if (StaticVariableController.coinCount - doubleJumpCost < 0)
        {
            StartCoroutine(showErrorMessage("You don't have enough coins to get an extra jump.", 2));
        }
        else
        {
            StaticVariableController.subsequentJumpsRemaining += 1;
            StaticVariableController.coinCount -= doubleJumpCost;
        }
    }

    public void getDash()
    {
        if (StaticVariableController.coinCount - dashCost < 0)
        {
            StartCoroutine(showErrorMessage("You don't have enough coins to get the Dash ability.", 2));
        }
        else
        {
            StaticVariableController.canDash = true;
            StaticVariableController.coinCount -= dashCost;
        }

    }

    public void increaseArmor()
    {
        if (StaticVariableController.coinCount - armorCost < 0)
        {
            StartCoroutine(showErrorMessage("You don't have enough coins to increase your armor.", 2));
        }
        else
        {
            StaticVariableController.DamageMitigation *= 0.75f;
            StaticVariableController.coinCount -= armorCost;
        }
    }

    IEnumerator showErrorMessage(string msg, float delay)
    {
        thisText.text = msg;
        thisText.enabled = true;
        yield return new WaitForSeconds(delay);
        thisText.enabled = false;
    }
}
