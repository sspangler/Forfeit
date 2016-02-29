using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {

	public int cost;
	public int def;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) {
				col.GetComponent<PlayerStats> ().currency -= cost;
				col.GetComponent<PlayerStats> ().protectedHits += 1;
				Destroy (this.gameObject);
			}
		}
	}
}