using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	PlayerStats playerStats;
	ProjectileStats projectileStats;

	Vector3 orgPos;

	public float damage;
	public float knockBack;

	// Use this for initialization
	void Start () {
		projectileStats = GetComponentInParent<ProjectileStats>();
		orgPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (transform.tag == "PlayerProjectile" && col.transform.tag == "Ground") {
			Destroy (this.gameObject);
		}

		if (col.transform.tag == "Enemy" && transform.tag == "PlayerProjectile") {
			col.gameObject.GetComponent<EnemyStats> ().TakeRangedDamage (damage);
			col.gameObject.GetComponent<EnemyStats> ().KnockBack (knockBack, transform.position);
			Destroy (this.gameObject);
		} else if (col.transform.tag == "Player" && transform.tag == "EnemyProjectile") {
			playerStats = col.gameObject.GetComponent<PlayerStats>();
			playerStats.health -= projectileStats.damage;
			Destroy(this.gameObject);
		}

		if (col.transform.tag == "DestroyTaskObj" && transform.tag == "PlayerProjectile") {
			col.transform.GetComponent<DestructableObj> ().TakeDamage (damage);
		}
	}
}