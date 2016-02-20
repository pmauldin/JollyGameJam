using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	// Use this for initialization
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
		Debug.Log (col.gameObject);
		if (col.gameObject.tag == "Player")
		{
			var obj = col.gameObject;
			// obj.GetComponent<PlayerCar> ().setVelocity (0.75);
			Debug.Log("Collision with Tree");
		}
	}
}
