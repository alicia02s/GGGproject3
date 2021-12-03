using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTrigger : MonoBehaviour
{

	private Transform bossTransform;

	private BossEnemy boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<BossEnemy>();
        bossTransform = boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = bossTransform.position;
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if (other.gameObject.tag == "Player") {
    		boss.ShootPlayerTrue();
    		StartCoroutine(boss.ShootThePlayer());
    	}
    }

    void OnTriggerExit2D(Collider2D other) {
    	if (other.gameObject.tag == "Player") {
    		boss.ShootPlayerFalse();
    		StopCoroutine(boss.ShootThePlayer());
    	}
    }
}
