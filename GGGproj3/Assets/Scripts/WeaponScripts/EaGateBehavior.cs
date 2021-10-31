using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaGateBehavior : MonoBehaviour
{
    Vector2 lookingDirection;
    [SerializeField]
    [Tooltip("Bullet shot by this weapon")]
    private GameObject m_BulletPrefab;

    [SerializeField]
    [Tooltip("Initial velocity of bullet")]
    private float InitialVelocity;

    [SerializeField]
    [Tooltip("Bullet Duration")]
    private float Duration;

    [SerializeField]
    [Tooltip("Random Duration Amount")]
    private float RandomAmt;

    // Start is called before the first frame update
    void Start()
    {
        lookingDirection = GetComponentInParent<EaEmptyBehavior>().lookingDirection;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg));
        StartCoroutine(DurationTimer());
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private IEnumerator DurationTimer()
    {
        yield return new WaitForSeconds(Duration + Random.Range(0, 2 * RandomAmt));
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(Duration + Random.Range(-RandomAmt, RandomAmt));
        GameObject bullet = Instantiate(m_BulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = lookingDirection * InitialVelocity;
        yield return new WaitForSeconds(Duration + Random.Range(-RandomAmt, RandomAmt));
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(Duration * 2);
        Destroy(transform.parent.gameObject);
    }
}
