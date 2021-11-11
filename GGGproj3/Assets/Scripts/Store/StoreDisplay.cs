using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    public Text coinCountDisplay;

    void Start()
    {
        coinCountDisplay.text = "You have " + StaticVariableController.coinCount.ToString() + " coins.";
    }

    private void Update()
    {
        coinCountDisplay.text = "You have " + StaticVariableController.coinCount.ToString() + " coins.";
    }
}
