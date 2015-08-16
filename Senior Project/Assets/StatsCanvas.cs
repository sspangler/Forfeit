using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StatsCanvas : MonoBehaviour {

	public PlayerStats playerStats;
	public List<Text> stats = new List<Text> ();
	//public Text stats;


	// Use this for initialization
	void Start () {
		UpdateStats ();
	}


	void Update () {

	}

	public void UpdateStats () {
		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		stats [0].text = "Health:" + playerStats.health;
		stats [1].text = "Defence:" + playerStats.defence;
		stats [2].text = "Melee Damage:" + playerStats.meleeDamage;
		stats [3].text = "Swing Rate:" + (playerStats.meleeAttackSpeed * 10);
		stats [4].text = "Ranged Damage:" + playerStats.rangedDamage;
		stats [5].text = "Fire Rate:" + (playerStats.rangedAttackSpeed * 10);
		stats [6].text = "Move Speed:" + playerStats.moveSpeed;
	}
}
