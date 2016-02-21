using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
	Transform playerTransform;

	public float initialAcceleration = 0.1f;
	public float acceleration;
	public float sideSpeed = 3;
	public float initialVelocity = 0.5f;
	public Vector3 velocity;
	public bool loop = true;
	Vector3 initialPos;

	float timeRemainingLimit = -1;

	public float maxJumpHeight = 0.6f;
	public float jumpSpeed = 0.01f;
	int jumpDirection = 1;
	bool jumping = false;

	public Animation animation; 
	public bool inputEnabled;

	// Use this for initialization
	void Start () {
		Debug.Log (this.animation.GetClip ("spin").averageDuration);
		playerTransform = GetComponentInParent<Transform> ();
		acceleration = initialAcceleration;
		velocity = new Vector3(0, 0, -initialVelocity);
		initialPos = playerTransform.position;
		inputEnabled = true;
		Debug.Log("initialPos: " + initialPos);
	}
	
	// Update is called once per frame
	void Update () {
		if (inputEnabled) {
			handleInput (); 
		}

		handleAccelTime ();

		if (jumping && playerTransform.position.y < initialPos.y) {
			jumping = false;
			Debug.Log (this.animation.name);
			this.animation.Play ("wobble");
			Vector3 pos = playerTransform.position;
			pos.y = initialPos.y;
			playerTransform.position = pos;
		}

		if (loop && playerTransform.position.z > 25) {
			Vector3 pos = playerTransform.position;
			pos.z = -36;
			playerTransform.position = pos;
		}
	}

	void FixedUpdate() {
		velocity.z += acceleration;
		playerTransform.Translate (velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, velocity.z * Time.deltaTime);

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
		if (jumpDirection == 1 && playerTransform.position.y >= initialPos.y + maxJumpHeight) {
			jumpDirection = -1;
		}

		Vector3 pos = playerTransform.position;
		pos.y += jumpDirection * jumpSpeed * Time.deltaTime;
		playerTransform.position = pos;
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
//		Debug.Log (this.velocity.z + " * " + velocity + " = " + (this.velocity.z * velocity));
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
