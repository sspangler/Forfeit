using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public int rangeCounter;
	public float moveSpeed;
	public float swingCooldown = 4f;
	public float swingDelay = 1f;

	Rigidbody2D enemyRigidbody;
	SpriteRenderer spriterend;

	bool isLeft, isRight;
	public bool isGroundLeft, isGroundRight;
	public bool moveLeft, moveRight;

	Vector2 direction;
	GameObject player;

	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		spriterend = GetComponent<SpriteRenderer> ();
	}


	void Update () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (rangeCounter == 1) {
			if (moveLeft && isGroundLeft) {
				transform.Translate (Vector2.left * moveSpeed * Time.fixedDeltaTime);
				spriterend.flipX = true;
			} else if (moveRight && isGroundRight) {
				transform.Translate (Vector2.right * moveSpeed * Time.fixedDeltaTime);
				spriterend.flipX = false;
			}
		} else if (rangeCounter >= 2) {
			if (player.transform.position.x < transform.position.x  && isGroundLeft) { //left
				spriterend.flipX = true;
				moveLeft = true;
				moveRight = false;
				transform.Translate (Vector2.left * moveSpeed * Time.fixedDeltaTime);
			}else if (player.transform.position.x > transform.position.x && isGroundRight) { //left
				spriterend.flipX = false;
				moveLeft = false;
				moveRight = true;
				transform.Translate (Vector2.right * moveSpeed * Time.fixedDeltaTime);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			rangeCounter++;
			player = col.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			rangeCounter--;
		}
	}

}