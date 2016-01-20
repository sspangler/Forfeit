using UnityEngine;
using System.Collections;

public class OneWayPlatforms : MonoBehaviour {
	public Collider2D thisCollider;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.position.y < transform.position.y) { //might need to change the .5 with character changes
			Physics2D.IgnoreCollision(col, thisCollider);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		Physics2D.IgnoreCollision(col, thisCollider, false);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().onOneWay = true;
			col.gameObject.GetComponent<PlayerController> ().oneWayCol = thisCollider;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.transform.tag == "Player") {
			//Physics2D.IgnoreCollision (col.collider, thisCollider, false);
		}
	}
}
