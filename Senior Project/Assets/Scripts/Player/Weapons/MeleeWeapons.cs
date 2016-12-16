using UnityEngine;
using System.Collections;

public class MeleeWeapons : MonoBehaviour {
	public float attackSpeed;
	float totalAttackDamage;
	public float slashDamage;
	public float pierceDamage;
	public float smashingDamage;
	public float knockBack; //1 - almost none       10 - insane amount

	public bool canAttack = true;

	BoxCollider2D weaponCol;

	public Vector3 startPos;
	public Vector3 startRot;

	public bool swinging;
	float timer;
	//must release between swings

	// Use this for initialization
	void Start () {
		//startPos = transform.localPosition;
		//startRot = transform.localEulerAngles;
		setPos();
		weaponCol = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (swinging) {
			timer += Time.deltaTime;
			if (timer < .25f)
				transform.RotateAround (transform.parent.position, -transform.forward, 375 * Time.deltaTime);
			else if (timer >= attackSpeed) {
				timer = 0;
				swinging = false;
				canAttack = true;
				transform.localPosition = startPos;
				transform.localEulerAngles = startRot;
			} else if (timer >= .25f) {
				weaponCol.enabled = false;
			}
		}
	}

	public void StartAttackLeft () {
		if (canAttack) {
			swinging = true;
			canAttack = false;
			weaponCol.enabled = true;
			transform.localPosition = startPos;
		}
	}

	public void StartAttackRight () {
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
			col.gameObject.GetComponent<EnemyStats> ().KnockBack (knockBack, transform.parent.transform.position);
		}

		if (col.tag == "DestroyTaskObj") {
			col.GetComponent<DestructableObj> ().TakeDamage (smashingDamage + slashDamage + pierceDamage);
		}

		if (col.tag == "EnemyProjectile") {
			Destroy (col.gameObject);
		}

	}

	public void setPos () {
		startPos = transform.localPosition;
		startRot = transform.localEulerAngles;
	}
}