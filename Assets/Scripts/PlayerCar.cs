using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
	Transform transform;

	public float initialAcceleration = 0.1f;
	public float acceleration;
	public float sideSpeed = 3;
	public float initialVelocity = 0.5f;
	public float maxJumpHeight = 0.6f;
	public float jumpSpeed = 0.01f;
	public Vector3 velocity;
	public bool loop = true;
	Vector3 initialPos;
	int jumpDirection = 1;

	float timeRemainingLimit = -1;

	bool jumping = false;

	// Use this for initialization
	void Start () {
		transform = GetComponentInParent<Transform> ();
		acceleration = initialAcceleration;
		velocity = new Vector3(0, 0, -initialVelocity);
		initialPos = transform.position;
		Debug.Log("initialPos: " + initialPos);
	}
	
	// Update is called once per frame
	void Update () {
		handleInput (); 
		handleAccelTime ();

		if (jumping && transform.position.y < initialPos.y) {
			jumping = false;
			Vector3 pos = transform.position;
			pos.y = initialPos.y;
			transform.position = pos;
		}

		if (loop && transform.position.z > 25) {
			Vector3 pos = transform.position;
			pos.z = -36;
			transform.position = pos;
		}
	}

	void FixedUpdate() {
		velocity.z += acceleration;
		transform.Translate (velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, velocity.z * Time.deltaTime);

		if (jumping) {
			jump ();
		}
	}

	void handleInput() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			velocity.x = -sideSpeed;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			velocity.x = sideSpeed;
		} else {
			velocity.x = 0;
		}

		if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && !jumping) {
			jumping = true;
			jumpDirection = 1;
		}
	}

	void jump() {
		if (jumpDirection == 1 && transform.position.y >= initialPos.y + maxJumpHeight) {
			jumpDirection = -1;
		}

		Vector3 pos = transform.position;
		pos.y += jumpDirection * jumpSpeed * Time.deltaTime;
		transform.position = pos;
	}

	void handleAccelTime() {
		if(timeRemainingLimit > -1){

			if(timeRemainingLimit > 0){
				timeRemainingLimit -= 1;
			}
			else{
				resetAcceleration();
				timeRemainingLimit = -1;
			}
		}
	}

	public void setVelocity(float velocity){
		this.velocity.z *= velocity;
	}

	public void setAcceleration(float acceleration, float timeLimit ){ 
		acceleration *= acceleration;
		timeRemainingLimit = timeLimit;

	}

	public void resetAcceleration(){ 
		acceleration = initialAcceleration;

	}
}
