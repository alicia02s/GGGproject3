using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBehavior : MonoBehaviour
{
    public WickedPortalBehavior portal;
    public Vector2 lookingDirection;
    public GameObject fistTail;
    public GameObject fistFarTail;
    public GameObject mask;
    public float velocity;
    public float startTime;
    public float extraTime;
    private bool completed = true;

    void Awake()
    {
        StartCoroutine(DurationStart());
    }

    private void Update()
    {
        if (!completed)
        {
            // check if fist should stop moving
            if (!isPast())
            {
                transform.position += (Vector3)lookingDirection * velocity * Time.deltaTime;
            }
            else
            {
                completed = true;
                StartCoroutine(DurationDestroy());
            }

            // portal masking
            Vector3 fistTailPos = fistFarTail.transform.position;
            float distance = (portal.gameObject.transform.position - fistTailPos).magnitude;
            Vector2 center = (portal.gameObject.transform.position + fistTailPos) / 2;
            mask.transform.localScale = new Vector3(distance, mask.transform.localScale.y, mask.transform.localScale.z);
            mask.transform.position = center;
        }
    }

    bool isPast()
    {
        Vector2 tailPosition = (fistTail.transform.position - portal.gameObject.transform.position).normalized;
        if (Vector2.Dot(tailPosition, lookingDirection) < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private IEnumerator DurationDestroy()
    {
        yield return new WaitForSeconds(extraTime);
        Destroy(portal.gameObject);
        Destroy(transform.gameObject);
    }

    private IEnumerator DurationStart()
    {
        yield return new WaitForSeconds(startTime);
        completed = false;
    }
}
