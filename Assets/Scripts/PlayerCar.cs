using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
	public Transform transform;

	public float acceleration = 9;
	public float sideSpeed = 100;
	Vector3 velocity = new Vector3(0, -1000, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			velocity.x = sideSpeed;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			velocity.x = -sideSpeed;
		} else {
			velocity.x = 0;
		}

		if (transform.position.z < -4000) {
			Vector3 pos = transform.position;
			pos.z = 4000;
			transform.position = pos;
		}
	}

	void FixedUpdate() {
		velocity.y -= acceleration;
		transform.Translate (velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, velocity.z * Time.deltaTime);
		Debug.Log ("Velocity is " + velocity);
	}
}
