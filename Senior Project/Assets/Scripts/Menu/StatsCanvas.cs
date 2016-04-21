using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StatsCanvas : MonoBehaviour {

	public PlayerStats playerStats;
	public AbilitySelection abilitySelect;
	public List<Text> stats = new List<Text> ();
	bool gameStarted;
	
	// Use this for initialization
	void Start () {
		UpdateStats ();
		DontDestroyOnLoad (this.gameObject);
	}
		
	void OnLevelWasLoaded () {
		gameStarted = true;
		GetComponent<Canvas> ().enabled = false;
	}

	public void UpdateStats () {
		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		stats [0].text = "" + playerStats.health;
		stats [1].text = "" + playerStats.strength;
		stats [2].text = "" + playerStats.dexterity;
		stats [3].text = "" + playerStats.agility;
		if(!gameStarted)
			stats [4].text = "Select " + abilitySelect.availPoints + " Abilities";
	}
}
