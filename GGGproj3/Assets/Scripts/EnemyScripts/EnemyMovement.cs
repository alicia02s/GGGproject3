using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("How much health the enemy has")]
	private int m_MaxHealth;

	[SerializeField]
	[Tooltip("How fast the enemy can move")]
	private float m_Speed;

	[SerializeField]
	[Tooltip("How much damage is dealt by the enemy")]
	private float m_Damage;
	#endregion

	#region Private Variables
	// current health of the enemy
	private float e_CurHealth; 
	// rigidbody component of the enemy
	private Rigidbody2D e_Rb;
	// transform of the player
	private Transform p_Player;
	#endregion

	#region Initialization
	// set initial variables before anything else happens
	private void Awake() {
		e_CurHealth = m_MaxHealth;
		e_Rb = GetComponent<Rigidbody2D>();
	}
    // Start is called before the first frame update
    void Start() {
        p_Player = FindObjectOfType<PlayerMovement>().transform;
    }
    #endregion
    
    #region Main Updates
    // controls the movement of the enemy
    private void FixedUpdate() {
    	Vector2 direction = p_Player.position - transform.position;
    	direction.Normalize();
    	Vector2 newPos = new Vector2(direction.x, 0);
    	e_Rb.velocity = newPos * m_Speed;
    }
    #endregion

    #region Collision Methods
    void OnCollisionEnter2D(Collision2D collision) {
    	if (collision.gameObject.tag == "Player") {
    		// DecreasePlayerHealth(m_Damage);
    	}
    }
    #endregion

    #region Health Methods
    // decreases the enemy's health, to be used by the player scripts
    public void DecreaseEnemyHealth(float amount) {
    	e_CurHealth -= amount;
    	if (e_CurHealth <= 0) {
    		Destroy(gameObject);
    	}
    }
    #endregion
}
