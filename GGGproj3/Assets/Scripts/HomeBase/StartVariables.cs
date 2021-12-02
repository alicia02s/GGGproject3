using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVariables : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Starting pistol")]
    private GameObject basicPistol;

    [SerializeField]
    [Tooltip("Starting shotgun")]
    private GameObject basicShotgun;

    // Start is called before the first frame update
    void Start()
    {
        if (!StaticVariableController.availableWeapons.Contains(basicPistol))
        {
            StaticVariableController.availableWeapons.Add(basicPistol);
        }
        if (!StaticVariableController.availableWeapons.Contains(basicShotgun))
        {
            StaticVariableController.availableWeapons.Add(basicShotgun);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
