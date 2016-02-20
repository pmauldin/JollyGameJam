using UnityEngine;
using System.Collections;

public class SpikeStrip : MonoBehaviour {

	public float VelocitySlow = 0.75f;
	public float AccelSlow = 0.75f;
	public float AccelSlowDuration = 3.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			var obj = col.gameObject.GetComponent<PlayerCar> ();
			/*obj.setVelocity (VelocitySlow);
			obj.setAcceleration (AccelSlow, AccelSlowDuration);*/
			Debug.Log ("Collision");
		}
	}
}
