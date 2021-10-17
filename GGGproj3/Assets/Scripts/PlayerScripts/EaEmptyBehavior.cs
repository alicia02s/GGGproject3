using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaEmptyBehavior : MonoBehaviour
{
    public Vector2 lookingDirection;

    // Start is called before the first frame update
    void Awake()
    {
        lookingDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
    }
}
