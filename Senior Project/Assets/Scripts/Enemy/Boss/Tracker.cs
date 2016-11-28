using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {

	public bool bottomSides;
	public bool topSides;
	public bool middleSides;
	public bool middleMiddle;
	public bool botMiddle;

	public Warden WardenAI;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			if (bottomSides)
				WardenAI.bottomSides = true;
			else if (topSides)
				WardenAI.topSides = true;
			else if (middleSides)
				WardenAI.middleSides = true;
			else if (middleMiddle)
				WardenAI.middleMiddle = true;
			else if (botMiddle)
				WardenAI.botMiddle = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			if (bottomSides)
				WardenAI.bottomSides = false;
			else if (topSides)
				WardenAI.topSides = false;
			else if (middleSides)
				WardenAI.middleSides = false;
			else if (middleMiddle)
				WardenAI.middleMiddle = false;
			else if (botMiddle)
				WardenAI.botMiddle = false;
		}
	}
}
