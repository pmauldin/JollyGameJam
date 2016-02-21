using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class LoserBoardScrollView : MonoBehaviour {
	ScoreKeeper scoreKeeper;

	void Start() {
		scoreKeeper = GameObject.FindGameObjectWithTag ("ScoreKeeper").GetComponent<ScoreKeeper> ();
		scoreKeeper.printPlayers ();
	}

	void OnGUI() {
		
	}
}