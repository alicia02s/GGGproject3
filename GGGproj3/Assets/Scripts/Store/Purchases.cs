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

    public void buyWeapon(GameObject weapon)
    {
        StaticVariableController.availableWeapons.Add(weapon);
        // Block out the button so you can't buy this weapon again
    }

    public void getDoubleJump()
    {
        StaticVariableController.subsequentJumpsRemaining = 1;
        StaticVariableController.coinCount -= doubleJumpCost;
        Debug.Log(StaticVariableController.coinCount);
    }

    public void getDash()
    {
        StaticVariableController.canDash = true;
    }

    public void increaseArmor()
    {
        StaticVariableController.DamageMitigation /= 2;
    }
}