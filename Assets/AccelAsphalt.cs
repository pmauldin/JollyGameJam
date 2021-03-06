﻿using UnityEngine;
using System.Collections;

public class AccelAsphalt : MonoBehaviour {

    public const int MULTIPLIER = 2;
    bool isColliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (!isColliding && col.gameObject.tag == "Car") {
            gameObject.GetComponentInParent<PlayerCar>().velocity *= MULTIPLIER;
            Debug.Log("Colliding: velocity is " + gameObject.GetComponentInParent<PlayerCar>().velocity.z);
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        isColliding = false;
    }
}
