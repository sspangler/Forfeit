using UnityEngine;
using System.Collections;

public class OneWayPlatforms : MonoBehaviour {
	public BoxCollider2D thisCollider;

	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().onOneWay = true;
			col.gameObject.GetComponent<PlayerController> ().oneWayCol = thisCollider;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		ContactPoint2D contact = col.contacts [0];
		if (col.transform.tag == "Player" && (Vector3.Dot(contact.normal, Vector2.up) > .5f)) { //if below
			Physics2D.IgnoreCollision (col.collider, thisCollider, false);
			col.gameObject.GetComponent<PlayerController> ().onOneWay = false;
		} 
	}
}