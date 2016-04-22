using UnityEngine;
using System.Collections;

public class Debuffer : MonoBehaviour {

	public GameObject projectile;
	public float shotSpeed;

	public float speed;
	public string debuff;
	GameObject player;

	bool inRange;

	float cooldown = 22f;
	float delay = 3f;

	float cooldown2 = 6f;
	float delay2 = 2f;

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
		if (inRange) {
			cooldown -= Time.deltaTime;
			cooldown2 -= Time.deltaTime;

			if (cooldown < 0) {
				delay -= Time.deltaTime;
				if (delay <= 0)
					ApplyDebuff ();
			}

			if (cooldown2 < 0) {
				delay2 -= Time.deltaTime;
				if (delay2 <= 0)
					Fire ();
			}
		}

		if (inRange && Vector3.Distance (transform.position, player.transform.position) < 5) {
			direction = transform.position - player.transform.position;
			transform.Translate (direction.normalized * speed * Time.fixedDeltaTime);
		}
			
	}

	void Fire() {
		direction = player.transform.position - transform.position;
		GameObject proj = (GameObject)Instantiate (projectile, transform.position , Quaternion.identity);
		proj.GetComponent<Rigidbody2D> ().velocity = direction.normalized * shotSpeed;
		proj.GetComponent<Rigidbody2D> ().gravityScale = 0;
		proj.GetComponent<ProjectileStats> ().damage = GetComponent<EnemyStats> ().damage;
		delay2 = 2;
		cooldown2 = 5;
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

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			inRange = false;
		}
	}
}