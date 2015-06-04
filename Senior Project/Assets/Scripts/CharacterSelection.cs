﻿using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject abilitiesCanvas;
	public GameObject titleCanvas;
	public GameObject[] characters = new GameObject[4];
	public GameObject selectedCharacter;

	public Vector3 characterPos = new Vector3 (5.18f,.12f,0);

	int prevChar = 0;

	//----------------------------------------------------
	bool toAbilities;
	bool toStart;

	Vector3 abilitiesPos = new Vector3 (11,0,-10);
	Vector3 startPos = new Vector3 (-18, 0, -10);
	//----------------------------------------------------
	
	// Use this for initialization
	void Start () {
		abilitiesCanvas.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (toAbilities) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, abilitiesPos, 10 * Time.deltaTime);
			if (mainCamera.transform.position == abilitiesPos) {
				toAbilities = false;
				abilitiesCanvas.SetActive(true);
				selectedCharacter = GameObject.FindGameObjectWithTag("Player");
				abilitiesCanvas.GetComponent<AbilitySelection>().player = selectedCharacter;
				abilitiesCanvas.GetComponent<AbilitySelection>().playerStats = selectedCharacter.GetComponent<PlayerStats>();
				this.gameObject.SetActive(false);
			}
		}

		if (toStart) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, startPos, 15 * Time.deltaTime);
			if (mainCamera.transform.position == startPos) {
				toStart = false;
				titleCanvas.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}

	}


	public void SelectCharacter (int character) {
		if (character != prevChar) {
			Destroy (GameObject.FindGameObjectWithTag ("Player"));
			Instantiate (characters [character], characterPos, Quaternion.identity);
			prevChar = character;
			abilitiesCanvas.GetComponent<AbilitySelection>().ResetBools();
		}
	}

	public void MoveToAbilities () {
		toAbilities = true;
	}

	public void MoveToTitle () {
		toStart = true;
	}
}
