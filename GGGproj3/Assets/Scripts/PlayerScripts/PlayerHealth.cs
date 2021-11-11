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

    // [SerializeField]
    // [Tooltip("Related to armor")]
    private float DamageMitigation;
    void Start()
    {
        currHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage * DamageMitigation;
        Debug.Log(currHealth);
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
