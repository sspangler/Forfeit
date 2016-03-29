using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	bool inRange;

	public float swingCooldown = 4f;
	public float swingDelay = 1f;


	Rigidbody2D enemyRigidbody;

	bool isLeft, isRight;

	Vector2 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			inRange = true;
		}
	}

}
