using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("The bounds of the spawner")]
	private Vector2 m_Bounds;

	[SerializeField]
	[Tooltip("A list of all enemies and their information")]
	private EnemySpawnInfo[] m_Enemies;
	#endregion
    
	#region Initialization
	private void Awake() {
		StartSpawning();
	}
	#endregion

	#region Spawn Methods
	public void StartSpawning() {
		for (int i = 0; i < m_Enemies.Length; i++) {
			StartCoroutine(Spawn(i));
		}
	}

	private IEnumerator Spawn(int enemyIndex) {
		EnemySpawnInfo info = m_Enemies[enemyIndex];
		int i = 0;
		while (info.AlwaysSpawn || i < info.NumberToSpawn) {
			yield return new WaitForSeconds(info.TimeToNextSpawn);
			float xVal = m_Bounds.x / 2;
			float yVal = m_Bounds.y / 2;
			Vector2 spawnPos = new Vector2(Random.Range(-xVal, xVal), Random.Range(-yVal, yVal));
			spawnPos += (Vector2)transform.position;
			Instantiate(info.EnemyGameObject, spawnPos, Quaternion.identity);
			if (!info.AlwaysSpawn) {
				i++;
			}
		}
	}
	#endregion
}
