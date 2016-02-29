﻿using UnityEngine;
using System.Collections;

public class ExtDoor : MonoBehaviour {

	bool atDoor;
	public bool taskComplete;

	public GameObject forfeitCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (atDoor && Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.LeftControl)) {
			if (taskComplete)
				LoadNextLevel ();
			else {
				Instantiate (forfeitCanvas, transform.position, Quaternion.identity);
			}
		}
	}

	void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			atDoor = true;
		}
	}
}