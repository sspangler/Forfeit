using UnityEngine;
using System.Collections;

public class OneWayTrigger : MonoBehaviour {
	public BoxCollider2D thisCollider;

	void Start () {
		thisCollider = transform.parent.GetComponent<BoxCollider2D> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.position.y < transform.position.y) { //might need to change the .5 with character changes
			Physics2D.IgnoreCollision(col, thisCollider);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		Physics2D.IgnoreCollision(col, thisCollider, false);
	}
}