using UnityEngine;
using System.Collections;

public class Cyclone : MonoBehaviour {

	public BoxCollider2D cycloneCol;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void initAtack (Transform pos) {
		print ("Cyclone");
		cycloneCol.enabled = true;
		Invoke ("stopAttack", 4f);
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			col.GetComponent<PlayerStats> ().TakeDamage (10);
			print ("hit");
		}
	}

	void stopAttack () {
		cycloneCol.enabled = false;
	}
}
