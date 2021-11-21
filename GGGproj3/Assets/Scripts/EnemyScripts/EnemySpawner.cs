using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("A list of all enemies and their information")]
	private EnemySpawnInfo[] m_Enemies;

	[SerializeField]
	[Tooltip("Radius from the player that the enemies should spawn at")]
	private float m_Radius;

	[SerializeField]
	[Tooltip("Radius from the player that the enemies should not spawn at")]
	private float m_InnerRadius;
	#endregion

	static float numEnemies;

	#region Initialization
	private void Awake() {
		numEnemies = 0;
		for (int i = 0; i < m_Enemies.Length; i++)
		{
			EnemySpawnInfo info = m_Enemies[i];
			if (!info.AlwaysSpawn)
            {
				numEnemies += info.NumberToSpawn;
            }
		}
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
			Vector2 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
			float yVal = playerPos.y + 0.5f;
			Vector2 spawnPos = new Vector2(Random.Range(m_InnerRadius, m_Radius), 0);
			if (Random.Range(0f,1f) > 0.3f) // Unbalanced, to make enemies spawn ahead of the player more often
            {
				spawnPos += new Vector2(playerPos.x, yVal);
            }
			else
            {
				spawnPos = new Vector2(playerPos.x, yVal) - spawnPos;
			}
			if (spawnPos != playerPos) {
				spawnPos += (Vector2)transform.position;
				Instantiate(info.EnemyGameObject, spawnPos, Quaternion.identity);
				if (!info.AlwaysSpawn) {
					i++;
				}
			}
		}
	}

	public static void DecreaseNumEnemies()
    {
		numEnemies -= 1;
		Debug.Log(numEnemies);
	}
	#endregion
}
