using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float maxHealth;
	public float strength;
	public float dexterity;
	public float agility;

	public int currency;
	public int protectedHits;

	bool inGrace;
	float graceTimer;
	void Start () {
		avalPoints = 5;
		maxHealth = health;
		DontDestroyOnLoad (this.gameObject);
	}

	void Update () {
		if (inGrace) {
			graceTimer -= Time.deltaTime;
			if (graceTimer < 0) {
				inGrace = false;
				Physics2D.IgnoreLayerCollision (13, 14, false);
				graceTimer = 1.0f;
				GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Enemy" && !inGrace) {
			inGrace = true;
			Physics2D.IgnoreLayerCollision (13, 14, true);
			GetComponent<SpriteRenderer> ().color = Color.red;
			if (protectedHits > 0)
				protectedHits--;
			else {
				health -= col.gameObject.GetComponent<EnemyStats> ().damage;
				Vector3 direction = col.transform.position - transform.position;
				//KnockBack ();
			}
			
			if (health <= 0) {
				//Invoke ("Dead", 2f);
				//Destroy (this.gameObject);
			}
		}
	}

//	public void KnockBack () {
//			Vector2 direction = transform.position - pos;
//			Vector2 force = direction.normalized;
//			GetComponent<Rigidbody2D> ().velocity = Vector2.up * 20;
//			GetComponent<Rigidbody2D> ().velocity = force * knockback * 3;
//	}

	void Dead () {
		Application.LoadLevel (0);
	}
}