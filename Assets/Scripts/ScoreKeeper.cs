using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreKeeper : MonoBehaviour {
	float timer = 0;

	List<PlayerStats> players;

	void Start() {
		Object.DontDestroyOnLoad (this);
		players = new List<PlayerStats>();
	}

	void FixedUpdate() {
		timer += Time.deltaTime;
	}

	public void addPlayer(PlayerStats stats) {
		stats.time = timer;
		players.Add (stats);
	}

	public void printPlayers() {
		players.ForEach ((player) => {
			player.print();
		});
	}

	public List<PlayerStats> getPlayers() {
		players.Sort (delegate(PlayerStats x, PlayerStats y) {
			return y.time.CompareTo(x.time);
		});
		return players;
	}

	public int size() {
		return players.Count;
	}
}
