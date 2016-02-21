using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public string name;
	public float time;
	public int numTrees;
	public int numBananas;
	public int numOils;
	public int numSpikes;

	void Start() {
//		Object.DontDestroyOnLoad (this);
	}

	public void print() {
		Debug.Log(string.Format ("{0}: Time = {1}, Trees Hit = {2}, Bananas Hit = {3}, Oil Spills Hit = {4}, Spikes Hit = {5}",
										name, time, numTrees, numBananas, numOils, numSpikes));
	}
}
