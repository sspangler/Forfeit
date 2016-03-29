using UnityEngine;
using System.Collections;

public class MeleeWeapons : MonoBehaviour {
	public float attackSpeed;
	float totalAttackDamage;
	public float slashDamage;
	public float pierceDamage;
	public float smashingDamage;
	public float knockBack;

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
				weaponCol.enabled = false;
				transform.localPosition = startPos;
				transform.localEulerAngles = startRot;
			}
		}
	}

	public void StartAttack () {
		if (canAttack) {
			swinging = true;
			canAttack = false;
			weaponCol.enabled = true;
			transform.localPosition = startPos;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy" && !col.isTrigger) {
			col.gameObject.GetComponent<EnemyStats> ().TakeDamage (slashDamage, slashDamage, smashingDamage);
			col.gameObject.GetComponent<EnemyStats> ().KnockBack (knockBack, transform.position);
			if (col.gameObject.GetComponent<EnemyStats> ().health <= 0) {
				Destroy (col.gameObject);
			}
		}
	}
}