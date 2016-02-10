using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float maxHealth;
	public float strength;
	public float dexterity;
	public float agility;

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
			}
		}
	}

//	void OnTriggerEnter2D (Collider2D col) {
//		if (col.tag == "Enemy" && !inGrace) {
//			inGrace = true;
//			health -= col.gameObject.GetComponent<EnemyStats> ().damage;
//			if (health <= 0)
//				print ("Dead");
//		}
//	}
}