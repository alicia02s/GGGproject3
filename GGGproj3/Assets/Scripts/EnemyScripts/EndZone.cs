using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene("HomeBase");
            if (SceneManager.GetActiveScene().name.Equals("LevelOne"))
            {
                StaticVariableController.playerWonL1 = true;
            } else if (SceneManager.GetActiveScene().name.Equals("LevelTwo"))
            {
                StaticVariableController.playerWonL2 = true;
            }
            else if (SceneManager.GetActiveScene().name.Equals("LevelThree"))
            {
                StaticVariableController.playerWonL3 = true;
            }
            else if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
            {
                StaticVariableController.playerWonL4 = true;
            }
        }
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
