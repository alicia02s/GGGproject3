using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button levelTwoButton;
    public Button levelThreeButton;
    public Button levelFourButton;
    public Button bossLevel;
    // Start is called before the first frame update
    void Start()
    {
        checkPlayerWon(levelTwoButton);
        checkPlayerWon(levelThreeButton);
        checkPlayerWon(levelFourButton);
        checkPlayerWon(bossLevel);
    }

    private void checkPlayerWon(Button button)
    {
        if (button.name.Equals("LevelTwo"))
        {
            if (StaticVariableController.playerWonL1)
            {
                button.enabled = true;
                button.GetComponentInChildren<Text>().enabled = true;
            }
            else
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
            }
        }
        if (button.name.Equals("LevelThree"))
        {
            if (StaticVariableController.playerWonL2)
            {
                button.enabled = true;
                button.GetComponentInChildren<Text>().enabled = true;
            }
            else
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
            }
        }
        if (button.name.Equals("LevelFour"))
        {
            if (StaticVariableController.playerWonL3)
            {
                button.enabled = true;
                button.GetComponentInChildren<Text>().enabled = true;
            }
            else
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
            }
        }
        if (button.name.Equals("BossLevel"))
        {
            if (StaticVariableController.playerWonL4)
            {
                button.enabled = true;
                button.GetComponentInChildren<Text>().enabled = true;
            }
            else
            {
                button.enabled = false;
                button.GetComponentInChildren<Text>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
