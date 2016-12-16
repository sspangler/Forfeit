using UnityEngine;
using System.Collections;

public class Cyclone : MonoBehaviour {

	public BoxCollider2D cycloneCol;
	public ParticleSystem leftFacing;
	public ParticleSystem rightFacing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void initAtack (Transform pos) {
		cycloneCol.enabled = true;
		leftFacing.Play ();
		rightFacing.Play ();
		Invoke ("stopAttack", 4f);
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			col.GetComponent<PlayerStats> ().TakeDamage (10);
		}
	}

	void stopAttack () {
		cycloneCol.enabled = false;
	}
}
