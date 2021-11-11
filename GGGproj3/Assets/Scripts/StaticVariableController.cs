using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariableController : MonoBehaviour
{
    public static int coinCount = 0;

    public static GameObject weaponChoice;

    public static ArrayList availableWeapons = new ArrayList();

    public static int subsequentJumpsRemaining = 0;

    public static bool canDash = false;

    public static float DamageMitigation = 1; // default value gives us no damage mitigation, the lower the value the greater the damage is mitigated (aka the less damage we take)
}
