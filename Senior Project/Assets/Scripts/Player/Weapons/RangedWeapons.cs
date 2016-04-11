using UnityEngine;
using System.Collections;

public class RangedWeapons : MonoBehaviour {

	public GameObject projectile;
	public float fireRate;
	public float damage;

	public float bulletSpeed;
	public float knockBack;

	public bool canFire;

	float timer;
	public Rigidbody2D playerRig;
	// Use this for initialization
	void Start () {

	}

	void OnLevelWasLoaded () {
		playerRig = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < fireRate)
			timer += Time.deltaTime;
		
		if (timer >= fireRate) {
			canFire = true;
		}
	}

	void StartAttackLeft () {
		if (canFire) {
			GameObject projClone = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			projClone.GetComponent<Rigidbody2D> ().velocity += Vector2.left * bulletSpeed;
			projClone.transform.up = projClone.GetComponent<Rigidbody2D> ().velocity.normalized;
			projClone.GetComponent<ProjectileCollision> ().damage = damage;
			projClone.GetComponent<ProjectileCollision> ().knockBack = knockBack;
			canFire = false;
			timer = 0;
		}
	}

	void StartAttackRight () {
		if (canFire) {
			GameObject projClone = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			projClone.GetComponent<Rigidbody2D> ().velocity += Vector2.right * bulletSpeed;
			projClone.transform.up = projClone.GetComponent<Rigidbody2D> ().velocity.normalized;
			projClone.GetComponent<ProjectileCollision> ().damage = damage;
			projClone.GetComponent<ProjectileCollision> ().knockBack = knockBack;
			canFire = false;
			timer = 0;
		}
	}

	void StartAttackUp () {
		if (canFire) {
			GameObject projClone = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			projClone.GetComponent<Rigidbody2D> ().velocity += playerRig.velocity + Vector2.right * bulletSpeed;
			projClone.GetComponent<ProjectileCollision> ().damage = damage;
			projClone.GetComponent<ProjectileCollision> ().knockBack = knockBack;
			canFire = false;
			timer = 0;
		}
	}

	void StartAttackDown () {
		if (canFire) {
			GameObject projClone = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			projClone.GetComponent<Rigidbody2D> ().velocity += playerRig.velocity + Vector2.right * bulletSpeed;
			projClone.GetComponent<ProjectileCollision> ().damage = damage;
			projClone.GetComponent<ProjectileCollision> ().knockBack = knockBack;
			canFire = false;
			timer = 0;
		}
	}
}