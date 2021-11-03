using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAxeRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1000 * Time.deltaTime));
    }
}
