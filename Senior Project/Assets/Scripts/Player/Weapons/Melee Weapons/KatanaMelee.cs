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
		stats.meleeDamage = attackSpeed;
	}

	void Update () {
		if (!inMenu) {

			if (Input.GetKeyDown (KeyCode.Mouse0) && canAttack) {
				playerController.MeleeAttack ();
				canAttack = false;
			}
		
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				canAttack = true;
			}
		
			if (Input.GetKey (KeyCode.Mouse1)) {
			
			}

		}
	
	
	}
}