using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionHandler : MonoBehaviour {
	PlayerCar player;
	Dictionary<string, List<float>> collisionValues;

	float timer = 0;
	float buffDuration = 0;
	float slipTimer = 0;
	bool buffEnabled = false;
	bool slipping = false;
	Vector3 newVector;
	float magnitude;
    Color carColor;
    bool oiled = false;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerCar> ();
		this.collisionValues = createDict ();
        player.mat.SetColor("_Color", Color.white);
        carColor = player.mat.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
		if (buffEnabled) {
			timer += Time.deltaTime;

			if (timer > buffDuration) {
				disableBuffs ();
			}
		}

		if (slipping) {
			slip ();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (this.collisionValues.ContainsKey (col.gameObject.tag)) {
			List<float> values = this.collisionValues[col.gameObject.tag];
			player.setVelocity (values [0]);
			player.setAcceleration (values [1], values[2]);
            Debug.Log("Detected collision with " + col.gameObject.name);
		}

		if (col.gameObject.tag == "BananaPeel") {
			beginSlip ();
		} else if (col.gameObject.tag == "SpikeStrip" || col.gameObject.tag == "Oil") {
			disableInput (1);
		}

		if (col.gameObject.tag == "Oil") {
			slipping = false;
            oiled = true;
            carColor = player.mat.GetColor("_Color");
            player.mat.SetColor("_Color", Color.black);
        }

        Collider[] colliders = col.gameObject.GetComponentsInParent<Collider>();

        foreach (Collider collider in colliders)
        {
            Physics.IgnoreCollision(collider, GetComponentInParent<Collider>());
        }

		player.updateStats (col.gameObject.tag);

		buffEnabled = true;
	}

	Dictionary<string, List<float>> createDict() {
		Dictionary<string, List<float>> dict = new Dictionary<string, List<float>> ();

		dict.Add ("Tree", getCollisionOptions (0.5f, 1.0f, 0.0f));
		dict.Add ("SpikeStrip", getCollisionOptions (0.3f, 0.75f, 3.0f));
        dict.Add("SpeedBoost", getCollisionOptions(1.5f, 1.5f, 1.0f));

		return dict;
	}

	List<float> getCollisionOptions(float velocity, float acceleration, float accelDuration) {
		List<float> x = new List<float>();

		x.Add (velocity);
		x.Add (acceleration);
		x.Add (accelDuration);

		return x;
	}

	void disableInput(float duration) {
		player.inputEnabled = false;
		timer = 0;
		this.buffDuration = duration;
	}

	void disableBuffs() {
		buffEnabled = false;
		player.velocity.x = 0;
		player.inputEnabled = true;
		slipping = false;
        if (oiled)
        {
            oiled = false;
            player.mat.SetColor("_Color", carColor);
        }
	}

	void beginSlip() {
		player.animation.Play ("spin");
		disableInput (player.animation.GetClip ("spin").averageDuration);
		player.setAcceleration (0, player.animation.GetClip ("spin").averageDuration);
		slipping = true;

		magnitude = player.velocity.magnitude;
		float randomSpeed = magnitude + 1;

		while (Mathf.Abs (randomSpeed) >= Mathf.Abs (magnitude)) {
			randomSpeed = (((float) Random.Range(-2000, 2000)) / 1000) * player.sideSpeed;
		}

		newVector = new Vector3(randomSpeed, 0, Mathf.Sqrt((magnitude * magnitude) - (randomSpeed * randomSpeed)));

		slipTimer = 0;
	}

	void slip() {
		slipTimer += Time.deltaTime;
		float sign = newVector.x < 0 ? -1 : 1;
		Vector3 direction = new Vector3 (sign * Mathf.Sin (5 * Mathf.PI * slipTimer), 0, calculateZ ());
		Vector3 final = (direction + newVector.normalized).normalized * newVector.magnitude;

		player.velocity = final;
	}

	float calculateZ() {
		float sinResult = Mathf.Sin (5 * Mathf.PI * slipTimer);
		return Mathf.Sqrt (1 - (sinResult * sinResult));
	}
}
