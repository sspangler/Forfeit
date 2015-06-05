using UnityEngine;
using System.Collections;

public class AssultRifleRanged : MonoBehaviour {
	
	public float attackSpeed;
	public float attackDamage;

	public bool canAttack = true;
	public float attackTimer;

	PlayerStats stats;
	PlayerController playerController;
	bool inMenu;

	
	// Use this for initialization
	void Start () {
		stats = transform.parent.GetComponent<PlayerStats> ();
		playerController = transform.parent.GetComponent<PlayerController> ();
		stats.rangedAttackSpeed = attackSpeed;
		stats.rangedDamage = attackSpeed;
	}

	void Update () {
		if (inMenu) {
			if (!canAttack) {
				attackTimer -= Time.deltaTime;
				if (attackTimer <= 0) {
					canAttack = true;
					attackTimer = attackSpeed;
				}
			}

			if (Input.GetKey (KeyCode.Mouse0) && canAttack) {
				playerController.RangedAttack ();
				canAttack = false;
			}
		}
	}
}