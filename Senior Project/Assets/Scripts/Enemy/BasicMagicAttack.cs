using UnityEngine;
using System.Collections;

public class BasicMagicAttack : MonoBehaviour {

	public GameObject projectile;
	public float shotSpeed;

	public float speed;
	GameObject player;

	bool inRange;
	public int projNum;
	float cooldown = 5f;
	float delay = 1f;

	float cooldownTimer;
	float delayTimer;

	Rigidbody2D enemyRigidbody;
	Vector2 direction;


	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		cooldownTimer = cooldown;
		delayTimer = delay;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (inRange) {
			cooldownTimer -= Time.deltaTime;

			if (cooldownTimer < 0) {
				delayTimer -= Time.deltaTime;
				if (delayTimer <= 0)
					Fire ();
			}
		}

		if (inRange && Vector3.Distance (transform.position, player.transform.position) < 5) {
			direction = transform.position - player.transform.position;
			transform.Translate (direction.normalized * speed * Time.fixedDeltaTime);
		}

	}

	void Fire () {
		for (int i = 0; i < projNum; i++) {
			direction = (player.transform.position + (Random.insideUnitSphere * 2)) - transform.position; 
			GameObject proj = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			proj.GetComponent<Rigidbody2D> ().velocity = direction.normalized * shotSpeed;
			proj.GetComponent<Rigidbody2D> ().gravityScale = 0;
		}
		delayTimer = delay;
		cooldownTimer = cooldown;
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			inRange = true;
		}
	}

}