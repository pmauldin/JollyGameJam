using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	// Use this for initialization
	ChangeCarVelocity ccv = new ChangeCarVelocity ();
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Update");
	
	}

	void FixedUpdate()
	{
		
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Car")
		{
			//ccv.setVelocity (0);
			Debug.Log("Collision with Tree");
		}
	}
}
