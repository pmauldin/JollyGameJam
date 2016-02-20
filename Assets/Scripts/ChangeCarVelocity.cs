using UnityEngine;
using System.Collections;

public class ChangeCarVelocity : MonoBehaviour {
	PlayerCar player;
	float timeRemainingLimit = -1;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerCar> ();
	}
	
	// Update is called once per frame
	void Update () {

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
		player.velocity.z *= velocity;
	}

	public void setAcceleration(float acceleration, float timeLimit ){ 
		player.acceleration *= acceleration;
		timeRemainingLimit = timeLimit;

	}

	public void resetAcceleration(){ 
		player.acceleration = player.initialAcceleration;
	
	}
		
}
