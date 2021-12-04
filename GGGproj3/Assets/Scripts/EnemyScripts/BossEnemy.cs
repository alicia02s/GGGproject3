using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("How much health the boss has")]
	private int bossHealth;

	[SerializeField]
	[Tooltip("How fast the boss can move")]
	private float bossSpeed;

	[SerializeField]
	[Tooltip("How much damage is dealt by the boss")]
	private float bossDamage;

	[SerializeField]
	[Tooltip("The weapon that the boss can shoot")]
	private GameObject bossWeapon;

    [SerializeField]
    [Tooltip("True if this enemy is the boss, false otherwise")]
    private bool m_IsBoss;
	#endregion

	#region Private Variables
	// current health of the enemy
	private float e_CurHealth; 
	// rigidbody component of the enemy
	private Rigidbody2D e_Rb;
	// transform of the player
	private Transform p_Player;
	// inner trigger boolean for chasing
	private bool MoveTowardsPlayer;
	// outer trigger boolean for shooting
	private bool ShootPlayer;
	// weapon game object
	private GameObject PrimaryWeapon;
	#endregion

	#region Initialization
	// set initial variables before anything else happens
	private void Awake() {
		e_CurHealth = bossHealth;
		e_Rb = GetComponent<Rigidbody2D>();
		MoveTowardsPlayer = false;
		ShootPlayer = false;
	}
    // Start is called before the first frame update
    void Start() {
        p_Player = FindObjectOfType<PlayerMovement>().transform;
        PrimaryWeapon = Instantiate(bossWeapon, new Vector2(transform.position.x, transform.position.y) , transform.rotation);
        PrimaryWeapon.transform.parent = this.gameObject.transform;
    }
    #endregion
    
    #region Main Updates
    // controls the movement of the enemy
    private void FixedUpdate() {
    	if (MoveTowardsPlayer) {
    		Vector2 direction = p_Player.position - transform.position;
    		direction.Normalize();
    		Vector2 newPos = new Vector2(direction.x, 0);
    		e_Rb.velocity = newPos * bossSpeed;
    	}
    }

    public void ShootAtPlayer() {
    	// figure out how to shoot at player
    	StartCoroutine(ShootThePlayer());
    }

    public IEnumerator ShootThePlayer() {
    	while (ShootPlayer) {
    		PrimaryWeapon.GetComponent<WeaponInfo>().Action();
    		yield return new WaitForSeconds(0.1f);
    		PrimaryWeapon.GetComponent<WeaponInfo>().Action();
    		yield return new WaitForSeconds(0.1f);
    		PrimaryWeapon.GetComponent<WeaponInfo>().Action();
    		yield return new WaitForSeconds(0.1f);
    		PrimaryWeapon.GetComponent<WeaponInfo>().Action();
    		yield return new WaitForSeconds(0.1f);
    		PrimaryWeapon.GetComponent<WeaponInfo>().Action();
    		yield return new WaitForSeconds(0.5f);
    	}
    	
    }
    #endregion

    #region Helper Methods
    public void SetMovementTrue() {
    	MoveTowardsPlayer = true;
    }

    public void SetMovementFalse() {
    	MoveTowardsPlayer = false;
    }

    public void ShootPlayerTrue() {
    	ShootPlayer = true;
    }

    public void ShootPlayerFalse() {
    	ShootPlayer = false;
    }
    #endregion

    #region Collision Methods
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(bossDamage);
        }
    }
    #endregion

    #region Health Methods
    // decreases the enemy's health, to be used by the player scripts
    public void DecreaseBossEnemyHealth(float amount) {
        if (e_CurHealth > 0)
        {
            e_CurHealth -= amount;
            if (e_CurHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    #endregion
}
