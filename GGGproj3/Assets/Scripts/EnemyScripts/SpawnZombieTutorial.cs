using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieTutorial : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tutorial zombie to spawn")]
    private GameObject m_EnemyPrefab;
    private bool spawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !spawned)
        {
            spawned = true;
            Instantiate(m_EnemyPrefab, new Vector2(transform.position.x + 20, transform.position.y), transform.rotation);
            Instantiate(m_EnemyPrefab, new Vector2(transform.position.x + 25, transform.position.y), transform.rotation);
        }
    }
}
