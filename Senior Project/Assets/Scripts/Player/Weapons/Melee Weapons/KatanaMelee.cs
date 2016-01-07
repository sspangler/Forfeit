﻿using UnityEngine;
using System.Collections;

public class KatanaMelee : MonoBehaviour {

	public float attackSpeed;
	float totalAttackDamage;
	public float slashDamage;
	public float pierceDamage;
	public float smashingDamage;
	

	public bool canAttack = true;

	PlayerStats stats;
	PlayerController playerController;


	// Use this for initialization
	void Start () {

	}

	void Update () {
			if (Input.GetKeyDown (KeyCode.LeftArrow) && canAttack) {
				canAttack = false;
			}
			
			if (Input.GetMouseButtonUp(0)) {
				canAttack = true;
			}
		}
}