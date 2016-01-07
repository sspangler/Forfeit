using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StatsCanvas : MonoBehaviour {

	public PlayerStats playerStats;
	public AbilitySelection abilitySelect;
	public List<Text> stats = new List<Text> ();
	
	// Use this for initialization
	void Start () {
		UpdateStats ();
	}


	void Update () {

	}

	public void UpdateStats () {
		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		stats [0].text = "" + playerStats.health;
		stats [1].text = "" + playerStats.meleeDamage;
		stats [2].text = "" + playerStats.rangedDamage;
		stats [3].text = "" + playerStats.moveSpeed / 3;
		stats [4].text = "Select " + abilitySelect.avalPoints + " Abilities";
	}
}
