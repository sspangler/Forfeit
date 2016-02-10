using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float damage;
	public float slashRes;
	public float pierceRes;
	public float smashRes;

	// Use this for initialization
	void Start () {
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
