﻿using UnityEngine;
using System.Collections;

public class SlopeDetector : MonoBehaviour {
	
	public PlayerController player;
	public bool isRight, isLeft;
	
	// Use this for initialization
	void Start () {
		
		player = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Ground") {
			if (isLeft) {
				player.isGroundLeft = true;
			} else if (isRight){
				player.isGroundRight = true;
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Ground") {
			if (isLeft) {
				player.isGroundLeft = false;
			} else {
				player.isGroundRight = false;
			}
		}
	}
}