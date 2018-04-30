using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {

	public bool isCaptured = false;


	void Start(){
		

	}

	void Update(){


	}


	void OnTriggerEnter(Collider col){
		var hit = col.gameObject;

		if (hit.tag == "Player" && !isCaptured) {
			var particle = GetComponent<ParticleSystem> ();
			particle.Stop ();

			hit.GetComponent<PointScript> ().GetFlag ();


			isCaptured = true;
			transform.position = hit.transform.position;
			transform.rotation = hit.transform.rotation;
			gameObject.transform.parent = hit.transform;


		}

	}



	void lost(){
		isCaptured = false;
		gameObject.transform.parent = null;


	}


}
