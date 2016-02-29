using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float damage;
	public float slashRes;
	public float pierceRes;
	public float smashRes;

	bool inGrace;
	float graceTimer;

	public bool dropKey;

	// Use this for initialization
	void Start () {
		maxHealth = health;
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

		if (dropKey && health <= 0) {
			GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<ExtDoor> ().taskComplete = true;
		}

	}
}