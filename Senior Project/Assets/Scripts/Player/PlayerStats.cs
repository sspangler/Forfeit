using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float defence;
	public float meleeDamage;
	public float rangedDamage;
	public float meleeAttackSpeed;
	public float rangedAttackSpeed;
	public float moveSpeed;
	public float maxAmmo;


	void Start () {
		avalPoints = 5;
		DontDestroyOnLoad (this.gameObject);
	}
	
}