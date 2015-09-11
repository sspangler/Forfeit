using UnityEngine;
using System.Collections;

public class KatanaMelee : MonoBehaviour {

	public float attackSpeed;
	public float attackDamage;

	public bool canAttack = true;

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

			if (Input.GetMouseButtonDown(0) && playerController.usingMelee) {
				canAttack = false;
			}
			
			if (Input.GetMouseButtonUp(0)) {
				canAttack = true;
			}
		}
	}
}