using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject enemyPrefab;
	public int numberOfEnemies;

	public override void OnStartServer(){
		for (int i = 0; i < numberOfEnemies; i++) {
			var spawnPosition = new Vector3 (Random.Range (-8.0f, 8.0f), 0.0f, Random.Range (-8f, 8f));

			var spawnRotation = Quaternion.Euler (0f, Random.Range (0, 180), 0f);
			var enemy = (GameObject)Instantiate (enemyPrefab, spawnPosition, spawnRotation);

			NetworkServer.Spawn (enemy);


		}


	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
