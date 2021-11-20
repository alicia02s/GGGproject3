using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacle1 : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealth>().Die();
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
