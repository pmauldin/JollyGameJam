using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishLine : MonoBehaviour {
	ScoreKeeper scoreKeeper;

	void Start() {
		scoreKeeper = GameObject.FindGameObjectWithTag ("ScoreKeeper").GetComponent<ScoreKeeper> ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Car") {
			PlayerStats player = col.gameObject.GetComponentInParent<PlayerStats> ();
			player.name = col.gameObject.name;
			scoreKeeper.addPlayer (player);
			Application.LoadLevel("LoserBoard");
		}
	}
}
