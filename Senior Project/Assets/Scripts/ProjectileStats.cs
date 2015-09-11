using UnityEngine;
using System.Collections;

public class ProjectileStats : MonoBehaviour {

	public float damage;
	public float speed;

	public Vector3 targetPos;

	PlayerStats playerStats;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;
		transform.LookAt(targetPos);
	}
}