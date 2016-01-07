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

	//must release between swings
	
	// Use this for initialization
	void Start () {

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
}