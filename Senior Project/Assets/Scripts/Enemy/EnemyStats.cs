using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float damage;
	public float slashRes;
	public float pierceRes;
	public float smashRes;
	public float knockbackRes;


	bool inGrace;
	float graceTimer;

	public bool dropKey;

	GameObject player;
	bool isActive;

	SpriteRenderer rend;
	Rigidbody2D rigBody;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		rend = GetComponent<SpriteRenderer> ();
		rigBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inGrace) {
			graceTimer -= Time.deltaTime;
			if (graceTimer < 0) {
				inGrace = false;
				graceTimer = .1f;
			}
		}

		if (isActive) {
			if (player.transform.position.x < transform.position.x)
				rend.flipX = true;
			else
				rend.flipX = false;
		}

		if (health <= 0) {
			if (dropKey)
				GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<ExtDoor> ().taskComplete = true;
			
			Destroy (this.gameObject);
		}

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			isActive = true;
			player = col.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			isActive = false;
		}
	}

	public void TakeDamage (float slash, float pierce, float smash) {
		health -= (slash * slashRes) + (pierce * pierceRes) + (smash * smashRes);
	}

	public void KnockBack (float knockback, Vector3 pos) {
		if (knockback > knockbackRes) {
			Vector3 direction = pos - transform.position;
			rigBody.AddForce(direction.normalized * (knockback * knockbackRes));
		}
	}
}