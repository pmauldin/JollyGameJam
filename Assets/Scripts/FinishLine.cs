using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionHandler : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "FinishLine") {
			Application.LoadLevel("LoserBoard");
		}
	}
}
