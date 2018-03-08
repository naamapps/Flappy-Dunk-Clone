using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
	public float jumpForce;
	public Rigidbody2D rb;
	public int combo =1;
	public int score = 0;
	public Text uiScore;
	public float forwardSpeed;
	bool didFlap = false;

	public bool gameOver = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {//for input
		uiScore.text = score.ToString();
		if (!gameOver) {
			if (Input.GetMouseButtonDown (0))
				didFlap = true;
		}
	}

	void FixedUpdate()//for movement
	{
		rb.AddForce (Vector2.right * forwardSpeed);

		if (didFlap) {
			rb.velocity = new Vector2 (rb.velocity.x, Vector2.up.y * jumpForce);
			didFlap = false;
		}
	}
}
