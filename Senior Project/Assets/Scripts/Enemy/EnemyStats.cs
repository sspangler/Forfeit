using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float damage;
	public float knockback;
	public float slashRes;
	public float pierceRes;
	public float smashRes;
	public float knockbackRes;


	bool inGrace;
	float graceTimer;

	public bool dropKey;

	GameObject player;

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

		if (health <= 0) {
			if (dropKey)
				GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<ExtDoor> ().taskComplete = true;
			
			Destroy (this.gameObject);
		}

	}

	public void TakeDamage (float slash, float pierce, float smash) {
		health -= (slash * (1 -slashRes)) + (pierce * (1-pierceRes)) + (smash * (1-smashRes));
	}

	public void KnockBack (float knockback, Vector3 pos) {
		if (knockback > knockbackRes) {
			Vector2 direction = transform.position - pos;
			Vector2 force = direction.normalized;
			rigBody.velocity = Vector2.up * 20;
			rigBody.velocity = force * knockback * (1 - knockbackRes )* 3;
			print ("asdfsd");
		}
	}
}