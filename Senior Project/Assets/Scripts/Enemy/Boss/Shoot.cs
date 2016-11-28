using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject fireBall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initAtack (Transform pos) {
		for (int i = 0; i < 5; i++) {
			GameObject fireBalls = (GameObject)Instantiate (fireBall, transform.position, Quaternion.identity);
			Vector2 direction = (pos.position + (Random.insideUnitSphere * 2)) - transform.position; 
			fireBalls.GetComponent<Rigidbody2D> ().velocity = direction.normalized * 5f;
			fireBalls.GetComponent<Rigidbody2D> ().gravityScale = 0;
			fireBalls.GetComponent<ProjectileStats> ().damage = 10f;
		}
	}
}
