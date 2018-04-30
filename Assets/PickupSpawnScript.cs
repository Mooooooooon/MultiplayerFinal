using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PickupSpawnScript : NetworkBehaviour {
	public float spawnArea = 25.0f;

	public GameObject pickupPrefab;

	public override void OnStartServer(){
		SpawnPickup ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnPickup(){
		var pu = (GameObject) Instantiate(pickupPrefab,new Vector3(Random.Range(-spawnArea, spawnArea), 0, Random.Range(-spawnArea, spawnArea)), Quaternion.identity);
			
		NetworkServer.Spawn (pu);

	}
}
