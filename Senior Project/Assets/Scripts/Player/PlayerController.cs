using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	PlayerStats stats;
	Rigidbody2D playerRigidbody;
	float speed;
	float jumpForce = 10f;
	bool isGrounded;

	float forceDown;

	public bool leftDown, rightDown;
	public bool isGroundLeft, isGroundRight;


	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		speed = stats.moveSpeed;
		//Camera.main.transform.parent = this.gameObject.transform;

	}

	void OnLevelWasLoaded () {
		Camera.main.transform.parent = this.gameObject.transform;
		Camera.main.transform.localPosition = new Vector3 (0, 0, -10);
	}


	void Update () {

		if (Input.GetKeyDown (KeyCode.L)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		if (!isGrounded) {
			playerRigidbody.velocity += new Vector2 (0, forceDown);
			if (forceDown > -.1f)
				forceDown -= .5f * Time.deltaTime;
		} else 
			forceDown = 0;


		// MOVEMENT --------------------------------------------------------------------------------------
		// left and right movement
		if (Input.GetKey (KeyCode.A) && !isGroundLeft) {
			playerRigidbody.velocity = new Vector2 (-speed, playerRigidbody.velocity.y);
		} else if (Input.GetKey (KeyCode.D) && !isGroundRight) {
			playerRigidbody.velocity = new Vector2 (speed, playerRigidbody.velocity.y);
		} else {
			playerRigidbody.velocity = new Vector2 (0, playerRigidbody.velocity.y);
		}
		
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpForce);
		}

		// up and down movement
		// W for doors/stairs S for going through certain platforms

		//-------------------------------------------------------------------------------------------------
		//Attacking left right and down (possible up?)
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			ContactPoint2D contact = col.contacts [0];
			if (Vector3.Dot(contact.normal, Vector2.up) > .5f) { //might need to change the .5 with character changes
				isGrounded = true;
			}
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

}