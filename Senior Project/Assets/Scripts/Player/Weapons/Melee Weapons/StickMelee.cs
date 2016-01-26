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

	Vector3 startPos;
	Vector3 startRot;

	bool swinging;
	float timer;
	//must release between swings
	
	// Use this for initialization
	void Start () {
		startPos = transform.localPosition;
		startRot = transform.localEulerAngles;
		weaponCol = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && canAttack) {
			swinging = true;
			canAttack = false;
			transform.localPosition = startPos;
		}

		if (swinging) {
			timer += Time.deltaTime;
			if (timer < attackSpeed /2)
				transform.RotateAround (transform.parent.position, -transform.forward, attackSpeed * 1000 * Time.deltaTime);
			else {
				timer = 0;
				swinging = false;
				canAttack = true;
				transform.localPosition = startPos;
				transform.localEulerAngles = startRot;
			}
		}
	}
}