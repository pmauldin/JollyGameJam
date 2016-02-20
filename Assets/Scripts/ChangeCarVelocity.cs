using UnityEngine;
using System.Collections;

public class ChangeCarVelocity : MonoBehaviour {
	PlayerCar player;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerCar> ();
	}
	
	// Update is called once per frame
	void Update () {

			
	}

	public void setVelocity(float velocity){
		player.velocity.z *= velocity;
		Debug.Log ("Aseal Changed velocity: " + player.velocity);
	}

	public void setAcceleration(float acceleration){ 
		player.acceleration *= acceleration;
		Debug.Log ("set Acceleration: " + player.acceleration);

	}

	public void resetAcceleration(){ 
		player.acceleration = player.initialAcceleration;
		Debug.Log ("reset Acceleration: " + player.acceleration);
	
	}
}
