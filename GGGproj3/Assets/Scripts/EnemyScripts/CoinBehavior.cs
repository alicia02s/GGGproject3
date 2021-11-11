using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("How many points the coin is worth")]
	private int m_Value;
	#endregion

	#region Collision Methods
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			StaticVariableController.coinCount += m_Value;
			Destroy(gameObject);
		}
	}
	#endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
