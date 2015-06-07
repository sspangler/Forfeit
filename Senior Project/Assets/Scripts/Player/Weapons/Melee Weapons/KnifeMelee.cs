using UnityEngine;
using System.Collections;

public class KnifeMelee : MonoBehaviour {

	public float attackSpeed;
	public float attackDamage;

	public bool canAttack = true;
	public float attackTimer;

	PlayerStats stats;
	PlayerController playerController;
	bool inMenu = true;


	// Use this for initialization
	void Start () {
		stats = transform.parent.GetComponent<PlayerStats> ();
		playerController = transform.parent.GetComponent<PlayerController> ();
		stats.meleeAttackSpeed = attackSpeed;
		stats.meleeDamage = attackDamage;
	}

	void Update () {
		if (!inMenu) {
			if (!canAttack) {
				attackTimer -= Time.deltaTime;
				if (attackTimer <= 0) {
					canAttack = true;
					attackTimer = attackSpeed;
				}
			}

			if (Input.GetKeyDown (KeyCode.Mouse0) && canAttack) {
				playerController.MeleeAttack ();
				canAttack = false;
			}
		}
	}
}
