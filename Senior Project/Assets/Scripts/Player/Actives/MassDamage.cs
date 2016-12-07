using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MassDamage : MonoBehaviour {

	public List<GameObject> enemiesInRange = new List<GameObject>();
	public BoxCollider2D col;

	public float chargeTime;

	public float timer;
	public bool ready;

	// Use this for initialization
	void Start () {
		col = gameObject.AddComponent<BoxCollider2D> ();
		col.isTrigger = true;
		col.enabled = false;
		col.size = new Vector2 (5, 5);
		chargeTime = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!ready) {
			timer += Time.deltaTime;
			if (timer >= chargeTime)
				ready = true;
		}

		if (Input.GetKeyDown (KeyCode.F) && ready) {
			col.enabled = true;	
			Invoke ("BlowShitUp", .1f);
		}
	}

	void BlowShitUp () {
		foreach (GameObject enemy in enemiesInRange) {
			Destroy (enemy.gameObject, .1f);
		}
		enemiesInRange.Clear ();
		ready = false;
		timer = 0;
		col.enabled = false;
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