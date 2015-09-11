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
	bool inMenu = true;

	// Use this for initialization
	void Start () {
		stats = transform.parent.GetComponent<PlayerStats> ();
		playerController = transform.parent.GetComponent<PlayerController> ();
		stats.rangedAttackSpeed = attackSpeed;
		stats.rangedDamage = attackDamage;
	}

	void OnLevelWasLoaded () {
		inMenu = false;
	}

	void Update () {
		if (!inMenu) {
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

			if (Input.GetMouseButtonUp(0) && !playerController.usingMelee) {
				canAttack = true;
			}
		}
	}
}