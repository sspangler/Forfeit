using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	public bool isRight, isLeft;

	public Patrol controller;

	int groundCount;

	// Use this for initialization
	void Start () {
		controller = GetComponentInParent<Patrol> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Ground") {
			groundCount++;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Ground") {
			if (isLeft) {
				controller.isGroundLeft = true;
			} else if (isRight){
				controller.isGroundRight = true;
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Ground") {
			groundCount--;
			if (groundCount <= 0) {
				if (isLeft) {
					controller.isGroundLeft = false;
					controller.moveLeft = false;
					controller.moveRight = true;
				} else {
					controller.isGroundRight = false;
					controller.moveRight = false;
					controller.moveLeft = true;
				}
			}
		}
	}
}
