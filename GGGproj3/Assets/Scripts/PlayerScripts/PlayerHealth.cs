using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Starting player health")]
    private float MaxHealth;
    private float currHealth;
    private Animator animator;

    private Slider slider;
    // Start is called before the first frame update

    // [SerializeField]
    // [Tooltip("Related to armor")]
    private float DamageMitigation = StaticVariableController.DamageMitigation;
    void Start()
    {
        slider = FindObjectOfType<Slider>();
        SetSliderValue(1);
        currHealth = MaxHealth;

        //animation
        animator = animator.GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.y <= -20)
        {
            Die();

            //death animation
            animator.SetFloat("Health", 0);
        }
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage * DamageMitigation;
        Debug.Log(currHealth);
        SetSliderValue(currHealth / MaxHealth);
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("RealLoseScene");
    }

    void SetSliderValue(float value)
    {
        if (slider != null)
        {
            slider.value = value;
        }
    }

}
