using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MassDamage : MonoBehaviour {

	public List<GameObject> enemiesInRange = new List<GameObject>();
	public BoxCollider2D col;

	// Use this for initialization
	void Start () {
		col = gameObject.AddComponent<BoxCollider2D> ();
		col.isTrigger = true;
		col.enabled = false;
		col.size = new Vector2 (5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			col.enabled = true;	
			BlowShitUp ();
		}
	}

	void BlowShitUp () {
		foreach (GameObject enemy in enemiesInRange) {
			Destroy (enemy.gameObject, .1f);
		}
	}

	void OnTriggerEnter2D (Collider2D enemyCol) {
		if (enemyCol.tag == "Enemy")
			enemiesInRange.Add (enemyCol.gameObject);
	}

	void OnTriggerExit2D (Collider2D enemyCol) {
		if (enemyCol.tag == "Enemy")
			enemiesInRange.Remove (enemyCol.gameObject);
	}
}