using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	PlayerStats playerStats;
	ProjectileStats projectileStats;


	// Use this for initialization
	void Start () {
		projectileStats = GetComponentInParent<ProjectileStats>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col) {
		if (col.transform.tag == "Enemy" && this.transform.parent.tag == "PlayerProjectile") {
			//get enemy stats
		}
		else if (col.transform.tag == "Player" && this.transform.parent.tag == "EnemyProjectile") {
			playerStats = col.gameObject.GetComponent<PlayerStats>();
			playerStats.health -= projectileStats.damage * (playerStats.defence / 10);
			Destroy(this.gameObject);
		}
	}
}
