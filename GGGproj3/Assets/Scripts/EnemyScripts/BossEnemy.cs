using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("Boss's health")]
	private int BossMaxHealth;

	[SerializeField]
	[Tooltip("Boss's weapon")]
	private GameObject BossWeapon;

	[SerializeField]
	[Tooltip("Player transform")]
	private Transform PlayerTransform;

	[SerializeField]
	[Tooltip("How fast the boss can move")]
	private float BossSpeed;

	[SerializeField]
	[Tooltip("How much damage the boss does")]
	private float BossDamage;
	#endregion

	#region Private Variables
	private float CurrentBossHealth;
	private Rigidbody2D BossRigidbody;
	private Vector2 PlayerPosition;
	#endregion

	#region Health Methods
	public void DecreaseBossHealth(float amount) {
		if (CurrentBossHealth > 0) {
			CurrentBossHealth -= amount;
			if (CurrentBossHealth <= 0) {
				Die();
			}
		}
	}

	private void Die() {
		Destroy(gameObject);
	}
	#endregion

	#region Collision Methods
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(BossDamage);
		}
	}
	#endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
