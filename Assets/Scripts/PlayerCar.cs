using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
	public Transform transform;

	public float acceleration = 0.1f;
	public float sideSpeed = 3;
	public float initialVelocity = 0.5f;
	public float maxJumpHeight = 0.6f;
	public float jumpSpeed = 0.01f;
	public Vector3 velocity;
	Vector3 initialPos;
	int jumpDirection = 1;

	bool jumping = false;

	// Use this for initialization
	void Start () {
		velocity = new Vector3(0, -initialVelocity, 0);
		initialPos = transform.position;
		Debug.Log("initialPos: " + initialPos);
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

		if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && !jumping) {
			jumping = true;
			jumpDirection = 1;
		}

		if (jumping && transform.position.y < initialPos.y) {
			jumping = false;
			Vector3 pos = transform.position;
			pos.y = initialPos.y;
			transform.position = pos;
		}

		if (transform.position.z > 25) {
			Vector3 pos = transform.position;
			pos.z = -36;
			transform.position = pos;
		}
	}

	void FixedUpdate() {
		velocity.y -= acceleration;
		transform.Translate (velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, velocity.z * Time.deltaTime);
		Debug.Log ("Jumping: " + jumping);

		if (jumping) {
			if (jumpDirection == 1 && transform.position.y >= initialPos.y + maxJumpHeight) {
				jumpDirection = -1;
			}

			Vector3 pos = transform.position;
			pos.y += jumpDirection * jumpSpeed * Time.deltaTime;
			transform.position = pos;
		}
	}
}
