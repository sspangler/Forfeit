using UnityEngine;
using System.Collections;

public class PistolRanged : MonoBehaviour {
	
	public float attackSpeed;
	public float attackDamage;
	public float moveSpeed;

	public bool canAttack = true;

	public GameObject Projectile;

	PlayerController playerController;

	PlayerStats stats;

	// Use this for initialization
	void Start () {

	}

	void OnLevelWasLoaded () {
	}

	void Update () {
		//can only fire after click is released
		if (Input.GetMouseButtonDown(0) && canAttack) {
			GameObject fired = (GameObject) Instantiate(Projectile, transform.position, Quaternion.identity);
			fired.tag = "PlayerProjectile";
			ProjectileStats firedStats = fired.AddComponent<ProjectileStats>();
			firedStats.damage = attackDamage;
			firedStats.speed = moveSpeed;
			firedStats.targetPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			fired.transform.LookAt(firedStats.targetPos);
			canAttack = false;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) && canAttack) {
			canAttack = true;
		}
	}
}