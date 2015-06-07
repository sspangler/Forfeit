using UnityEngine;
using System.Collections;

public class PistolRanged : MonoBehaviour {
	
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
		stats.rangedAttackSpeed = attackSpeed;
		stats.rangedDamage = attackDamage;
	}

	void Update () {
		if (!inMenu) {
			//can only fire after click is released
			if (Input.GetKeyDown (KeyCode.Mouse0) && canAttack) {
				playerController.RangedAttack ();
				canAttack = false;
			}

			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				canAttack = true;
			}
		}
	}
}