using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float health;
	public float defence;
	public float meleeDamage;
	public float rangedDamage;
	public float moveSpeed;
	public float meleeAttackSpeed;
	public float maxAmmo;


	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}

}