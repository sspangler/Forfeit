using UnityEngine;
using System.Collections;

public class Debuffer : MonoBehaviour {

	public float speed;
	public string debuff;
	GameObject player;

	bool inRange;

	public float cooldown = 22f;
	public float delay = 3f;

	Rigidbody2D enemyRigidbody;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		cooldown = 2;
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (inRange && cooldown < 0) {
			delay -= Time.deltaTime;
			if (delay <= 0)
				ApplyDebuff ();
		}

		if (inRange && Vector3.Distance (transform.position, player.transform.position) < 5) {
			direction = transform.position - player.transform.position;
			enemyRigidbody.AddForce(direction.normalized * speed);
		}

		if (cooldown >= 0 && inRange)
			cooldown -= Time.deltaTime;
	}

	void ApplyDebuff () {
		player.AddComponent (System.Type.GetType (debuff));
		cooldown = 22;
		delay = 3f;
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			inRange = true;
		}
	}
}
