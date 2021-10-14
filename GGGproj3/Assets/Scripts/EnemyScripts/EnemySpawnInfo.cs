using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The name of this enemy")]
    private string enemyName;

    [SerializeField]
    [Tooltip("The prefab of this enemy that will be spawned")]
    private GameObject enemyGO;

    [SerializeField]
    [Tooltip("The number of seconds before the next enemy  is spawned")]
    private float timeToSpawn;

    [SerializeField]
    [Tooltip("The number of enemies to spawn")]
    private int numberToSpawn;

    [SerializeField]
    [Tooltip("True if the enemies will continuously spawn")]
    private bool alwaysSpawn;
    #endregion

    #region Access Functions
    public string EnemyName {
    	get {
    		return enemyName;
    	}
    }

    public GameObject EnemyGameObject {
    	get {
    		return enemyGO;
    	}
    }

    public float TimeToNextSpawn {
    	get {
    		return timeToSpawn;
    	}
    }

    public int NumberToSpawn {
    	get {
    		return numberToSpawn;
    	}
    }

    public bool AlwaysSpawn {
    	get {
    		return alwaysSpawn;
    	}
    }
    #endregion
}
