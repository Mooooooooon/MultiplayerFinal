using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRegen : MonoBehaviour {
	

	void OnTriggerEnter(Collider col){
		


		var hit = col.gameObject;

		var health = hit.GetComponent<Health> ();


		if (hit.tag == "Player") {



			if (health != null) {
				health.TakeDamage (-50);
			}



			var spawner = GameObject.Find ("RegenSpawner").GetComponent<PickupSpawnScript> ();
			spawner.SpawnPickup ();
			Destroy (gameObject);
		}
	}

}
