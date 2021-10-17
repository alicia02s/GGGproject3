using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("The bounds of the spawner for the X axis")]
	private int m_BoundsX;

	[SerializeField]
	[Tooltip("The Y value the enemies should be spawned at")]
	private int m_BoundsY;

	[SerializeField]
	[Tooltip("A list of all enemies and their information")]
	private EnemySpawnInfo[] m_Enemies;
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
			float xVal = m_BoundsX / 2;
			float yVal = m_BoundsY;
			Vector2 spawnPos = new Vector2(Random.Range(-xVal, xVal), yVal);
			spawnPos += (Vector2)transform.position;
			Instantiate(info.EnemyGameObject, spawnPos, Quaternion.identity);
			if (!info.AlwaysSpawn) {
				i++;
			}
		}
	}

	public static void DecreaseNumEnemies()
    {
		numEnemies -= 1;
		if (numEnemies == 0)
        {
			SceneManager.LoadScene("HomeBase");
		}
		Debug.Log(numEnemies);
	}
	#endregion
}
