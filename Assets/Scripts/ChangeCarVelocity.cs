using UnityEngine;
using System.Collections;

public class ChangeCarVelocity : MonoBehaviour {
	PlayerCar player;
	float previousAcceleration;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerCar> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setVelocity(float acceleration){
		previousAcceleration = player.velocity.y;
		player.velocity.y -= acceleration;
		player.transform.Translate (player.velocity.x * Time.deltaTime, player.velocity.y * Time.deltaTime, player.velocity.z * Time.deltaTime);
		Debug.Log ("Changed velocity: " + player.velocity);
	}

	public void resetVelocity(){ 
		player.transform.Translate (player.velocity.x * Time.deltaTime, previousAcceleration * Time.deltaTime, player.velocity.z * Time.deltaTime);
		Debug.Log ("reset Velocity: " + player.velocity);
	
	}
}
