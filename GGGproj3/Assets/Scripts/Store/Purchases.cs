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
