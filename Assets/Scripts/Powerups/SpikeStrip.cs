using UnityEngine;
using System.Collections;

public class SpikeStrip : MonoBehaviour {

	public float VelocitySlow = 0f;
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

	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Car")
		{
			var car = col.gameObject.GetComponent<PlayerCar> ();
			car.setVelocity(VelocitySlow);
			Debug.Log ("Spikes");
		}
	}
}
