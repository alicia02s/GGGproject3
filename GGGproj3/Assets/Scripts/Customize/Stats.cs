using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text textObject = gameObject.GetComponent<Text>();
        textObject.text = "Stats: \n" + "Armor: " + (1 / StaticVariableController.DamageMitigation);
    }
}
