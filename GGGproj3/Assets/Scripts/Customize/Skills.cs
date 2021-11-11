using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text textObject = gameObject.GetComponent<Text>();
        textObject.text = "Skills: \n";
        if (StaticVariableController.subsequentJumpsRemaining > 0)
        {
            textObject.text += "Double Jump \n";
        }
        if (StaticVariableController.canDash)
        {
            textObject.text += "Dash \n";
        }
    }
}
