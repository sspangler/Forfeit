using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float maxHealth;
	public float strength;
	public float dexterity;
	public float agility;

	public float slashDamage;
	public float pierceDamage;
	public float smashDamage;

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
				graceTimer = .5f;
				GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Enemy" && !inGrace) {
			print ("hit");
			inGrace = true;
			GetComponent<SpriteRenderer> ().color = Color.red;
			health -= col.gameObject.GetComponent<EnemyStats> ().damage;
			if (health <= 0)
				print ("Dead");
		}
	}
}