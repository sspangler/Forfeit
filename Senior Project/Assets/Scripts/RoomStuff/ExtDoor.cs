using UnityEngine;
using System.Collections;

public class ExtDoor : MonoBehaviour {

	bool atDoor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (atDoor && Input.GetKeyDown (KeyCode.W)) {
			Application.LoadLevel(Application.loadedLevel + 1);
			atDoor = false;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			atDoor = true;
		}
	}
}
