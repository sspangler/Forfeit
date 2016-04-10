using UnityEngine;
using System.Collections;

public class WallCheck : MonoBehaviour {

	public bool isRight, isLeft;
	public Patrol controller;

	// Use this for initialization
	void Start () {
		controller = GetComponentInParent<Patrol> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Ground") {
			if (isLeft) {
				controller.moveLeft = false;
				controller.moveRight = true;
			} else if (isRight) {
				controller.moveLeft = true;
				controller.moveRight = false;
			}
		}
	}
}