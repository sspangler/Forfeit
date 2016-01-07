using UnityEngine;
using System.Collections;

public class KnifeMelee : MonoBehaviour {

	public float attackSpeed;
	float totalAttackDamage;
	public float slashDamage;
	public float pierceDamage;
	public float smashingDamage;

	public bool canAttack = true;
	public float attackTimer;

	PlayerStats stats;
	PlayerController playerController;


	// Use this for initialization
	void Start () {

	}

	void Update () {
		if (!canAttack) {
			attackTimer -= Time.deltaTime;
			if (attackTimer <= 0) {
				canAttack = true;
				attackTimer = attackSpeed;
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow) && canAttack) {
			//attack
			canAttack = false;
		}
	}
}
