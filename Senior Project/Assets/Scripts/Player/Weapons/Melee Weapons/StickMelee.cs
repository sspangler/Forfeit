using UnityEngine;
using System.Collections;

public class StickMelee : MonoBehaviour {

	public float attackSpeed;
	float totalAttackDamage;
	public float slashDamage;
	public float pierceDamage;
	public float smashingDamage;
	
	public bool canAttack = true;
	
	PlayerStats stats;
	PlayerController playerController;
	BoxCollider2D weaponCol;

	//must release between swings
	
	// Use this for initialization
	void Start () {
		weaponCol = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && canAttack) {

			canAttack = false;
		}
		
		if (Input.GetMouseButtonUp(0)) {
			canAttack = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		print (col.name);
	}
}