using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Starting player health")]
    private float MaxHealth;
    private float currHealth;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("RealLoseScene");
    }

}
