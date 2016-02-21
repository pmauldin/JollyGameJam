using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

class LoserBoardScrollView : MonoBehaviour {
	ScoreKeeper scoreKeeper;
	GameObject content;
	RectTransform contentTransform;

	public GameObject textPrefab;

	void Start() {
		scoreKeeper = GameObject.FindGameObjectWithTag ("ScoreKeeper").GetComponent<ScoreKeeper> ();

		for (int i = 1; i < 24; i++) {
			PlayerStats stats = new PlayerStats ();
			stats.name = "Player" + i;
			stats.numOils = 5;
			scoreKeeper.addPlayer (stats);
			stats.time = ((float) Random.Range (100, 500)) / 10f;
		}

		content = GameObject.FindGameObjectWithTag ("Content");
		contentTransform = content.GetComponent<RectTransform> ();
		Debug.Log (contentTransform.sizeDelta);

		Vector2 contentSize = contentTransform.sizeDelta;
		contentSize.y = (scoreKeeper.size () * 60) + 35;

		contentTransform.sizeDelta = contentSize;

		List<PlayerStats> players = scoreKeeper.getPlayers ();

		int index = 1;
		players.ForEach ((player) => {
			player.print();
			this.displayPlayer (player, index);
			index++;
		});
	}

	void displayPlayer (PlayerStats player, int index) {
		// Create text object/container and position it
		GameObject text = (GameObject) Instantiate (textPrefab);
		text.transform.parent = contentTransform;
		Vector3 pos = new Vector3 (0, -60 * (index - 1), 0);
		text.transform.localPosition = pos;

		// Set up place #
		Text placeText = this.getText(text, "Place");
		placeText.text = index.ToString () + ".";


		// Set up name
		Text nameText = this.getText(text, "Name");
		nameText.text = player.name;


		// Set up time
		Text timeText = this.getText(text, "Time");
		timeText.text = formatTime (player.time);

	}

	Text getText(GameObject parent, string type) {
		GameObject textContainer = parent.transform.Find(type).gameObject;
		return textContainer.GetComponent<Text> ();
	}

	string formatTime(float time) {
		int minutes = (int) time / 60;
		int seconds = (int) time % 60;
		int milliseconds = (int) (((time % 60) % 1) * 100);
		return string.Format ("{0:D2}:{1:D2}.{2:D2}", minutes, seconds, milliseconds);
	}
}