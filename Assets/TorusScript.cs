using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScript : MonoBehaviour {

	GameObject playerGameObject;
	playerScript player;
	bool touchedBad = false;
	bool gotPoint = false;
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindWithTag ("Player");
		if (playerGameObject != null)
			player = playerGameObject.GetComponent<playerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position.x > transform.position.x + 2f) && (player.transform.position.x < transform.position.x + 3f)) {
			if (!gotPoint) {
				player.gameOver = true;
				Debug.Log ("Game Over!");
			}
		}
		if (player.transform.position.x > transform.position.x + 4f) {
			if (gotPoint) {
				gotPoint = false;
				touchedBad = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			player.combo = 1;
			touchedBad = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			if (!gotPoint) {
				gotPoint = true;
				if (!touchedBad)
					player.combo++;
			}
			player.score += player.combo;
		}
	}
}
