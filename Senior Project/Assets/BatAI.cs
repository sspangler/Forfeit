using UnityEngine;
using System.Collections;

public class BatAI : MonoBehaviour {

	public int rangeCounter;
	public float moveSpeed;
	public float chargeSpeed;

	Rigidbody2D enemyRigidbody;

	bool isLeft, isRight;
	GameObject player;
	Vector3 target;

	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (rangeCounter == 1) {
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		} else if (rangeCounter == 2) {
			transform.position = Vector2.MoveTowards (transform.position, target, chargeSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			rangeCounter++;
			player = col.gameObject;
			if (rangeCounter == 2) {
				setTarget ();
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			rangeCounter--;
		}
	}

	void setTarget () {
		target = player.transform.position;
	}
}