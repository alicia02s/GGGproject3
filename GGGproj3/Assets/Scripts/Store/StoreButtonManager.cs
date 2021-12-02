using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButtonManager : MonoBehaviour
{
    public Button doubleJump;
    public Button dash;
    public Button increaseArmor;
    // Start is called before the first frame update
    void Start()
    {
        checkButtons(doubleJump);
        checkButtons(dash);
        checkButtons(increaseArmor);
    }

    private void checkButtons(Button button)
    {
        if (button.name.Equals("DoubleJump"))
        {
            if (StaticVariableController.subsequentJumpsRemaining >= 2)
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
                Image image = button.GetComponentInChildren<Image>();
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            }
        }
        if (button.name.Equals("Dash"))
        {
            if (StaticVariableController.canDash)
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
                button.GetComponentInChildren<Image>().enabled = false;
            }
        }
        if (button.name.Equals("IncreaseArmor")) 
        {
            if (StaticVariableController.DamageMitigation <= 0.5)
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
                button.GetComponentInChildren<Image>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkButtons(doubleJump);
        checkButtons(dash);
        checkButtons(increaseArmor);
    }
}
