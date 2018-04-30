using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class PointScript : NetworkBehaviour {
	[SyncVar(hook = "OnChangePoint")]
	public int point = 0;
	public bool hasFlag = false;
	public Text scoreText;
	private float timeelapsed;
	private float timeperPoint = 1.0f;



	void Update () {
		if (hasFlag) {
			gainPoint ();
		}
	}

	void gainPoint(){

		if (!isServer) {
			return;
		}

		if (timeelapsed > timeperPoint) {
			point++;
			timeelapsed = 0;
		} else {
			timeelapsed += Time.deltaTime;
		}

	}

	void OnChangePoint(int point){
		Text d = GameObject.Find ("ScoreText").GetComponent<Text>();
		d.text = ""+ point +"\n";
	}

	public void GetFlag(){

		hasFlag = true;
	}

	public void LoseFlag(){

		hasFlag = false;

	}

}
