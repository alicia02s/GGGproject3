using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void buyWeapon(GameObject weapon)
    {
        StaticVariableController.availableWeapons.Add(weapon);
        // Block out the button so you can't buy this weapon again
        if (weapon.name.Equals("BasicSniper"))
        {
            StaticVariableController.coinCount -= sniperCost;
        } else if (weapon.name.Equals("AxeHolder"))
        {
            StaticVariableController.coinCount -= axeCost;
        } else if (weapon.name.Equals("GrenadeLauncher"))
        {
            StaticVariableController.coinCount -= grenadeCost;
        } else if (weapon.name.Equals("RocketLauncher"))
        {
            StaticVariableController.coinCount -= rocketCost;
        } else if (weapon.name.Equals("Ea"))
        {
            StaticVariableController.coinCount -= EACost;
        }
    }

    public void getDoubleJump()
    {
        StaticVariableController.subsequentJumpsRemaining = 1;
        StaticVariableController.coinCount -= doubleJumpCost;
    }

    public void getDash()
    {
        StaticVariableController.canDash = true;
        StaticVariableController.coinCount -= dashCost;

    }

    public void increaseArmor()
    {
        StaticVariableController.DamageMitigation *= 0.75f;
        StaticVariableController.coinCount -= armorCost;
    }
}
