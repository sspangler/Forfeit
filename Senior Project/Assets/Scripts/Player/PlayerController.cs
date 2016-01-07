using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	PlayerStats stats;
	Rigidbody2D playerRigidbody;
	float speed;
	float jumpForce = 10f;
	bool isGrounded;

	float forceDown;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		speed = stats.moveSpeed;
	}

	void OnLevelWasLoaded () {
		Camera.main.transform.parent = this.gameObject.transform;
	}


	void Update () {

		if (!isGrounded) {
			playerRigidbody.velocity += new Vector2 (0, forceDown);
			if (forceDown > -.1f)
				forceDown -= .5f * Time.deltaTime;
		} else 
			forceDown = 0;


		// MOVEMENT --------------------------------------------------------------------------------------
		// left and right movement
		if (Input.GetKey (KeyCode.A)) {
			playerRigidbody.velocity = new Vector2 (-speed, playerRigidbody.velocity.y);
		} else if (Input.GetKey (KeyCode.D)) {
			playerRigidbody.velocity = new Vector2 (speed, playerRigidbody.velocity.y);
		} else {
			playerRigidbody.velocity = new Vector2 (0, playerRigidbody.velocity.y);
		}
		
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpForce);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {

		}
		// up and down movement
		// W for doors S for ????
		
		//-------------------------------------------------------------------------------------------------
		//Attacking left right and down (possible up?)
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

}