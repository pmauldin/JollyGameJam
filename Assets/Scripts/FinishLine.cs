using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishLine : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Car") {
			Application.LoadLevel("LoserBoard");
		}
	}
}
