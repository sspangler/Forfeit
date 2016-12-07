using UnityEngine;
using System.Collections;

public class ProjectileStats : MonoBehaviour {

	public float damage;
	public float speed;

	public Vector3 targetPos;

	PlayerStats playerStats;

	public float lifeTime;
	float counter;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter >= lifeTime)
			Destroy (this.gameObject);

		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			Destroy (this.gameObject);
			playerStats = col.gameObject.GetComponent<PlayerStats> ();
			playerStats.TakeDamage (damage);
		}
	}
}