using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float meleeDamage;
	public float rangedDamage;
	public float moveSpeed;

	public float meleeAttackSpeed;
	public float rangedAttackSpeed;


	void Start () {
		avalPoints = 5;
		DontDestroyOnLoad (this.gameObject);
	}
	
}