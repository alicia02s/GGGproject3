using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDuration : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet Duration")]
    private float Duration;

    void Awake()
    {
        StartCoroutine(DurationDestroy());
    }

    private IEnumerator DurationDestroy()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(transform.gameObject);
    }
}
