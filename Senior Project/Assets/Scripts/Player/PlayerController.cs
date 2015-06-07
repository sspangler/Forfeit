using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	PlayerStats stats;
	Rigidbody2D playerRigidbody;
	float speed = 5;
	bool inMenu = true;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!inMenu) {
			// left and right movement
			if (Input.GetKey (KeyCode.A)) {
				playerRigidbody.velocity = new Vector3 (-speed, playerRigidbody.velocity.y) * stats.moveSpeed;
			} else if (Input.GetKey (KeyCode.D)) {
				playerRigidbody.velocity = new Vector3 (speed, playerRigidbody.velocity.y) * stats.moveSpeed;
			} else {
				playerRigidbody.velocity = new Vector3 (0, playerRigidbody.velocity.y) * stats.moveSpeed;
			}
			// up and down movement
			if (Input.GetKey (KeyCode.W)) {
				playerRigidbody.velocity = new Vector3 (playerRigidbody.velocity.x, speed) * stats.moveSpeed;
			} else if (Input.GetKey (KeyCode.S)) {
				playerRigidbody.velocity = new Vector3 (playerRigidbody.velocity.x, -speed) * stats.moveSpeed;
			} else {
				playerRigidbody.velocity = new Vector3 (playerRigidbody.velocity.x, 0) * stats.moveSpeed;
			}
		}
	}


	public void MeleeAttack () {
		print ("melee attack");
	}

	public void RangedAttack () {
		print ("ranged attack");
	}
}
