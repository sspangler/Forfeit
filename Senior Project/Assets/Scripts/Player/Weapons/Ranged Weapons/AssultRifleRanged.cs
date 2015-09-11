using UnityEngine;
using System.Collections;

public class AssultRifleRanged : MonoBehaviour {
	
	public float attackSpeed;
	public float attackDamage;
	public float moveSpeed;

	public bool canAttack = true;
	public float attackTimer;

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
			if (!canAttack) {
				attackTimer -= Time.deltaTime;
				if (attackTimer <= 0) {
					canAttack = true;
					attackTimer = attackSpeed;
				}
			}

			if (Input.GetMouseButton(0) && canAttack && !playerController.usingMelee) {
				GameObject fired = (GameObject) Instantiate(Projectile, transform.position, Quaternion.identity);
				fired.tag = "PlayerProjectile";
				ProjectileStats firedStats = fired.AddComponent<ProjectileStats>();
				firedStats.damage = attackDamage;
				firedStats.speed = moveSpeed;
				firedStats.targetPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
				canAttack = false;
			}
		
		}
	}
}