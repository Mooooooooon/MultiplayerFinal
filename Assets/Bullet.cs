using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {
	void OnCollisionEnter(Collision col){
		
		var hit = col.gameObject;
		var health = hit.GetComponent<Health> ();
		if (hit.gameObject.tag == "Player") {

			if (health != null) {
				health.TakeDamage (20);
			}

			Destroy (gameObject);
		}
	}
}
