using UnityEngine;
using System.Collections;

public class MeleeWeapons : MonoBehaviour {
	public float attackSpeed;
	float totalAttackDamage;
	public float slashDamage;
	public float pierceDamage;
	public float smashingDamage;

	public bool canAttack = true;

	BoxCollider2D weaponCol;

	Vector3 startPos;
	Vector3 startRot;

	public bool swinging;
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

		if (swinging) {
			timer += Time.deltaTime;
			if (timer < attackSpeed / 2)
				transform.RotateAround (transform.parent.position, -transform.forward, attackSpeed * 1000 * Time.deltaTime);
			else if (timer >= attackSpeed) {
				timer = 0;
				swinging = false;
				canAttack = true;
				transform.localPosition = startPos;
				transform.localEulerAngles = startRot;
			}
		}
	}

	public void StartAttack () {
		if (canAttack) {
			swinging = true;
			canAttack = false;
			transform.localPosition = startPos;
		}
	}
}