using UnityEngine;
using System.Collections;

public class Splitter : MonoBehaviour {
	bool inRange;

	public float cooldown = 1f;
	public float delay = .5f;

	Rigidbody2D enemyRigidbody;

	bool isLeft, isRight;

	Vector2 direction;

	public int splitCount;

	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange && cooldown < 0) {
			delay -= Time.deltaTime;
			if (delay <= 0)
				Jump ();
		}

		if (cooldown >= 0 && inRange)
			cooldown -= Time.deltaTime;
	}

	void Jump() {
		enemyRigidbody.AddForce (direction * 200 + Vector2.up * 200);
		delay = .5f;
		cooldown = 1f;
	}

	void Split () {
		if (splitCount < 2) {
			for (int i = 0; i < 2; i++) {
				GameObject clone = (GameObject)Instantiate (this.gameObject, transform.position, Quaternion.identity);
				clone.transform.localScale = clone.transform.localScale / 1.5f;
				clone.GetComponent<Splitter> ().splitCount += 1;
				clone.GetComponent<EnemyStats> ().health = clone.GetComponent<EnemyStats> ().maxHealth;
			}
		}
		Destroy (this.gameObject);
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			inRange = true;
			if (col.transform.position.x - transform.position.x > 0) //to the right
				direction = Vector2.right;
			else
				direction = Vector2.left;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Player") {
			if (GetComponent<EnemyStats> ().health <= 0) {
				Split ();
			}
		}
	}
}