using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionHandler : MonoBehaviour {
	PlayerCar player;
	Dictionary<string, List<float>> collisionValues;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerCar> ();
		this.collisionValues = createDict ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (this.collisionValues.ContainsKey (col.gameObject.tag)) {
			List<float> values = this.collisionValues[col.gameObject.tag];
			player.setVelocity (values [0]);
			player.setAcceleration (values [1], values[2]);
		}
	}

	Dictionary<string, List<float>> createDict() {
		Dictionary<string, List<float>> dict = new Dictionary<string, List<float>> ();

		dict.Add ("Tree", getCollisionOptions (0.5f, 1, 0));
		dict.Add ("SpikeStrip", getCollisionOptions (0.1f, 0.75f, 3.0f));

		return dict;
	}

	List<float> getCollisionOptions(float velocity, float acceleration, float accelDuration) {
		List<float> x = new List<float>();

		x.Add (velocity);
		x.Add (acceleration);
		x.Add (accelDuration);

		return x;
	}
}
