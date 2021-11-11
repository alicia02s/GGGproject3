using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToEnd : MonoBehaviour
{
	#region Private Variables
	[SerializeField]
	[Tooltip("End Zone Position")]
	private Transform destination;
	#endregion
    // Start is called before the first frame update
    void Start()
    {
        //Vector2 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        //destination = FindObjectOfType<EndZone>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = new Vector2(destination.position.x - transform.position.x, destination.position.y - transform.position.y);
        transform.up = point;

    }
}
