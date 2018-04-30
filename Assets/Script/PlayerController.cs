using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;

	public Transform bulletSpawn;

	public float camviewF = 10.0f;
	public float camviewU = 7.0f;
	public float forwardSpeed = 6.0f;

	public override void OnStartLocalPlayer(){
		GetComponent<MeshRenderer> ().material.color = Color.blue;
		//Camera.main.GetComponent<CameraScript>().setTarget(gameObject.transform);
		Camera.main.transform.position = this.transform.position - this.transform.forward* camviewF  + this.transform.up*camviewU;
		Camera.main.transform.LookAt (this.transform.position);
		Camera.main.transform.parent = this.transform;
	}



	void Update () {
		if (!isLocalPlayer) {
			return;
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			CmdFire ();
		}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * forwardSpeed;

		transform.Rotate(0, x, 0);

		transform.Translate(0, 0, z);


	}

	[Command]
	void CmdFire(){
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 16f;

		NetworkServer.Spawn (bullet);
		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);

	}
}
