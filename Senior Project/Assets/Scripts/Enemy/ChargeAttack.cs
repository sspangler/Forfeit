using UnityEngine;
using System.Collections;

public class ChargeAttack : MonoBehaviour {

	bool inRange;

	public float cooldown = 4f;
	public float delay = 1f;

	Rigidbody2D enemyRigidbody;

	bool isLeft, isRight;

	Vector2 direction;

	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange && cooldown < 0) {
			delay -= Time.deltaTime;
			if (delay <= 0)
				Charge ();
		}

		if (cooldown >= 0 && inRange)
			cooldown -= Time.deltaTime;
	}

	void Charge () {
		enemyRigidbody.AddForce (direction * 1000);
		delay = .5f;
		cooldown = 2f;
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
}