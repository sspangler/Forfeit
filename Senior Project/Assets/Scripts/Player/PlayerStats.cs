using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float strength;
	public float dexterity;
	public float agility;


	void Start () {
		avalPoints = 5;
		DontDestroyOnLoad (this.gameObject);
	}
	
}