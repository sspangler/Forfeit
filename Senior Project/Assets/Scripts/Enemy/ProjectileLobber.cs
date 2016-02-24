using UnityEngine;
using System.Collections;

public class ProjectileLobber : MonoBehaviour {
	public GameObject projectile;

	public Vector3 direction;

	public float speed;
	GameObject player;

	public bool inRange;

	float cooldown = 22f;
	float delay = 3f;

	Rigidbody2D enemyRigidbody;

	float forceMultiplierX = 1;
	float forceMultiplierY = 1;
	float distance;
	int range;

	// Use this for initialization
	void Start () {
		cooldown = 2;
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange && cooldown < 0) {
			delay -= Time.deltaTime;
			if (delay <= 0) {
				direction = player.transform.position - transform.position;
				distance = Vector2.Distance (player.transform.position, transform.position);
				LobProj ();
			}
				
		}

		print(Vector3.Distance (transform.position, player.transform.position));
		if (inRange && Vector3.Distance (transform.position, player.transform.position) < 5) {
			direction = transform.position - player.transform.position;
			enemyRigidbody.AddForce(direction.normalized * speed);
		}

		if (cooldown >= 0 && inRange)
			cooldown -= Time.deltaTime;
	}

	void LobProj () {
		int projnum;
		if (range == 1) {
			projnum = 3;
		} else if (range == 2) {
			projnum = 2;
		} else {
			projnum = 1;
		}
		
		for (int i = 0; i < projnum; i++) {
			if (range == 1) {
				forceMultiplierX = Random.Range(2.5f,3.5f);
				forceMultiplierY = Random.Range(4.5f,5.5f);
			} else if (range == 2) {
				forceMultiplierX = Random.Range(1.5f,2f);
				forceMultiplierY = Random.Range(4f,5f);
			} else {
				forceMultiplierX = Random.Range(0.5f,1.5f);
				forceMultiplierY = Random.Range(1.5f,2.5f);
			}

			GameObject proj = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), proj.GetComponent<Collider2D> ());
			proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * forceMultiplierX, direction.y * forceMultiplierY));
		}
		cooldown = 2;
		delay = 3;
			
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			inRange = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			range++;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			range--;
		}
	}
}
